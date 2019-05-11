// ***********************************************************************
// Assembly         : Arithmetica
// Author           : Community
// Created          : 12-09-2018
//
// Last Modified By : Deepak Battini
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="NativeWrapper.cs" company="Arithmetica">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Arithmetica.Core;

namespace Arithmetica.Cpu
{
    /// <summary>
    /// Class NativeWrapper.
    /// </summary>
    internal static class NativeWrapper
    {
        /// <summary>
        /// Gets the method.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>MethodInfo.</returns>
        public static MethodInfo GetMethod(string name)
        {
            return typeof(CpuOpsNative).GetMethod(name, BindingFlags.Public | BindingFlags.Static);
        }

        /// <summary>
        /// Invokes the nullable result elementwise.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray InvokeNullableResultElementwise(MethodInfo method, params object[] args)
        {
            ArithArray resultTensor;
            if(args[0] == null)
            {
                var otherTensor = args.OfType<ArithArray>().First();
                resultTensor = ArrayResultBuilder.GetWriteTarget(null, otherTensor, false, otherTensor.Shape);
            }
            else
            {
                var resultSrc = (ArithArray)args[0];
                var otherTensor = args.OfType<ArithArray>().Skip(1).First();
                resultTensor = ArrayResultBuilder.GetWriteTarget(resultSrc, otherTensor, false, otherTensor.Shape);
            }

            args[0] = resultTensor;
            InvokeTypeMatch(method, args);
            return resultTensor;
        }

        /// <summary>
        /// Invokes the nullable result dimensionwise.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="extraArgs">The extra arguments.</param>
        /// <returns>Tensor.</returns>
        /// <exception cref="ArgumentOutOfRangeException">dimension</exception>
        public static ArithArray InvokeNullableResultDimensionwise(MethodInfo method, ArithArray result, ArithArray src, int dimension, params object[] extraArgs)
        {
            if (dimension < 0 || dimension >= src.Shape.Length) throw new ArgumentOutOfRangeException("dimension");

            var desiredSize = (long[])src.Shape.Clone();
            desiredSize[dimension] = 1;
            var resultTensor = ArrayResultBuilder.GetWriteTarget(result, src, false, desiredSize);

            var finalArgs = new List<object>(extraArgs.Length + 3);
            finalArgs.Add(resultTensor);
            finalArgs.Add(src);
            finalArgs.Add(dimension);
            finalArgs.AddRange(extraArgs);
            InvokeTypeMatch(method, finalArgs.ToArray());
            return resultTensor;
        }

        /// <summary>
        /// Invokes the type match.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="args">The arguments.</param>
        /// <exception cref="InvalidOperationException">All tensors must have the same argument types. Given: " + allTypes</exception>
        public static void InvokeTypeMatch(MethodInfo method, params object[] args)
        {
            var tensors = args.OfType<ArithArray>();
            if (tensors.Any())
            {
                var elemType = tensors.First().ElementType;
                if (!tensors.All(x => x.ElementType == elemType))
                {
                    var allTypes = string.Join(", ", tensors.Select(x => x.ElementType));
                    throw new InvalidOperationException("All tensors must have the same argument types. Given: " + allTypes);
                }
            }

            Invoke(method, args);
        }


        /// <summary>
        /// Builds the Array reference PTR.
        /// </summary>
        /// <param name="Array">The Array.</param>
        /// <param name="tensorRefPtr">The Array reference PTR.</param>
        /// <returns>IDisposable.</returns>
        public static IDisposable BuildTensorRefPtr(ArithArray Array, out IntPtr tensorRefPtr)
        {
            var tensorRef = NativeWrapper.AllocTensorRef(Array);
            var tensorPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TensorRef64)));
            Marshal.StructureToPtr(tensorRef, tensorPtr, false);

            tensorRefPtr = tensorPtr;

            return new DelegateDisposable(() =>
            {
                Marshal.FreeHGlobal(tensorPtr);
                NativeWrapper.FreeTensorRef(tensorRef);
            });
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="args">The arguments.</param>
        /// <exception cref="InvalidOperationException">Argument " + i + " is not a Cpu Array</exception>
        /// <exception cref="ApplicationException"></exception>
        public static void Invoke(MethodInfo method, params object[] args)
        {
            var freeListTensor = new List<TensorRef64>();
            var freeListPtr = new List<IntPtr>();

            try
            {
                for (int i = 0; i < args.Length; ++i)
                {
                    if (args[i] is ArithArray)
                    {
                        var Array = (ArithArray)args[i];
                        if (!(Array.Storage is CpuStorage))
                        {
                            throw new InvalidOperationException("Argument " + i + " is not a Cpu Array");
                        }

                        var tensorRef = AllocTensorRef(Array);
                        var tensorPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TensorRef64)));
                        Marshal.StructureToPtr(tensorRef, tensorPtr, false);
                        
                        args[i] = tensorPtr;

                        freeListTensor.Add(tensorRef);
                        freeListPtr.Add(tensorPtr);
                    }
                }

                //return method.Invoke(null, args);
                var result = (int)method.Invoke(null, args);
                if(result != 0)
                {
                    throw new ApplicationException(GetLastError());
                }
            }
            finally
            {
                foreach (var tensorRef in freeListTensor)
                {
                    FreeTensorRef(tensorRef);
                }

                foreach (var tensorPtr in freeListPtr)
                {
                    Marshal.FreeHGlobal(tensorPtr);
                }
            }
        }

        /// <summary>
        /// Checks the result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <exception cref="ApplicationException"></exception>
        public static void CheckResult(int result)
        {
            if (result != 0)
            {
                throw new ApplicationException(GetLastError());
            }
        }

        /// <summary>
        /// Gets the last error.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string GetLastError()
        {
            var strPtr = CpuOpsNative.TS_GetLastError();
            return Marshal.PtrToStringAnsi(strPtr);
        }


        /// <summary>
        /// Allocs the Array reference.
        /// </summary>
        /// <param name="Array">The Array.</param>
        /// <returns>TensorRef64.</returns>
        public static TensorRef64 AllocTensorRef(ArithArray Array)
        {
            var tensorRef = new TensorRef64();
            tensorRef.buffer = CpuNativeHelpers.GetBufferStart(Array);
            tensorRef.dimCount = Array.Shape.Length;
            tensorRef.sizes = AllocArray(Array.Shape);
            tensorRef.strides = AllocArray(Array.Strides);
            tensorRef.elementType = (CpuDType)Array.ElementType;
            return tensorRef;
        }

        /// <summary>
        /// Allocs the array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IntPtr.</returns>
        private static IntPtr AllocArray(long[] data)
        {
            var result = Marshal.AllocHGlobal(sizeof(long) * data.Length);
            Marshal.Copy(data, 0, result, data.Length);
            return result;
        }

        /// <summary>
        /// Frees the Array reference.
        /// </summary>
        /// <param name="tensorRef">The Array reference.</param>
        public static void FreeTensorRef(TensorRef64 tensorRef)
        {
            Marshal.FreeHGlobal(tensorRef.sizes);
            Marshal.FreeHGlobal(tensorRef.strides);
        }
    }
}
