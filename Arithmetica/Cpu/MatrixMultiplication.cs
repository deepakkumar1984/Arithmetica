// ***********************************************************************
// Assembly         : Arithmetica
// Author           : Community
// Created          : 12-09-2018
//
// Last Modified By : Deepak Battini
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="MatrixMultiplication.cs" company="Arithmetica">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arithmetica.Core;

namespace Arithmetica.Cpu
{
    /// <summary>
    /// Enum BlasOp
    /// </summary>
    internal enum BlasOp : byte
    {
        /// <summary>
        /// The non IntTranspose
        /// </summary>
        NonTranspose = (byte)'n',
        /// <summary>
        /// The IntTranspose
        /// </summary>
        Transpose = (byte)'t',
        /// <summary>
        /// The conjugate IntTranspose
        /// </summary>
        ConjugateTranspose = (byte)'c',
    }


    /// <summary>
    /// Class MatrixMultiplication.
    /// </summary>
    internal static class MatrixMultiplication
    {
        /// <summary>
        /// Dots the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        /// <exception cref="InvalidOperationException">All tensors must have the same element type</exception>
        /// <exception cref="ArgumentException">
        /// result must be a CPU array - result
        /// or
        /// lhs must be a CPU array - lhs
        /// or
        /// rhs must be a CPU array - rhs
        /// or
        /// lhs must have 1 dimension (ie. be a vector) - lhs
        /// or
        /// rhs must have 1 dimension (ie. be a vector) - rhs
        /// </exception>
        /// <exception cref="NotSupportedException">CPU vector dot product with element type " + result.ElementType + " not supported</exception>
        public static ArithArray Dot(ArithArray result, ArithArray lhs, ArithArray rhs)
        {
            if (lhs.ElementType != rhs.ElementType || (result != null && result.ElementType != lhs.ElementType))
                throw new InvalidOperationException("All tensors must have the same element type");
            if (result != null && !(result.Storage is CpuStorage)) throw new ArgumentException("result must be a CPU array", "result");
            if (!(lhs.Storage is CpuStorage)) throw new ArgumentException("lhs must be a CPU array", "lhs");
            if (!(rhs.Storage is CpuStorage)) throw new ArgumentException("rhs must be a CPU array", "rhs");

            if (lhs.DimensionCount != 1) throw new ArgumentException("lhs must have 1 dimension (ie. be a vector)", "lhs");
            if (rhs.DimensionCount != 1) throw new ArgumentException("rhs must have 1 dimension (ie. be a vector)", "rhs");


            var writeTarget = ArrayResultBuilder.GetWriteTarget(result, lhs, false, 1);

            if(writeTarget.ElementType == DType.Float32) Run_Dot_float(writeTarget, lhs, rhs);
            else if (writeTarget.ElementType == DType.Float64) Run_Dot_double(writeTarget, lhs, rhs);
            else
                throw new NotSupportedException("CPU vector dot product with element type " + result.ElementType + " not supported");

            return writeTarget;
        }

        /// <summary>
        /// Runs the dot float.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        private static void Run_Dot_float(ArithArray result, ArithArray lhs, ArithArray rhs)
        {
            unsafe
            {
                var resultPtr = (float*)CpuNativeHelpers.GetBufferStart(result);
                var lhsPtr = (float*)CpuNativeHelpers.GetBufferStart(lhs);
                var rhsPtr = (float*)CpuNativeHelpers.GetBufferStart(rhs);

                int n = (int)lhs.Shape[0];
                int incx = (int)lhs.Strides[0];
                int incy = (int)rhs.Strides[0];
                *resultPtr = OpenBlasNative.sdot_(&n, lhsPtr, &incx, rhsPtr, &incy);
            }
        }

        /// <summary>
        /// Runs the dot double.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        private static void Run_Dot_double(ArithArray result, ArithArray lhs, ArithArray rhs)
        {
            unsafe
            {
                var resultPtr = (double*)CpuNativeHelpers.GetBufferStart(result);
                var lhsPtr = (double*)CpuNativeHelpers.GetBufferStart(lhs);
                var rhsPtr = (double*)CpuNativeHelpers.GetBufferStart(rhs);

                int n = (int)lhs.Shape[0];
                int incx = (int)lhs.Strides[0];
                int incy = (int)rhs.Strides[0];
                *resultPtr = OpenBlasNative.ddot_(&n, lhsPtr, &incx, rhsPtr, &incy);
            }
        }

        /// <summary>
        /// Muls the m v.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        /// <exception cref="InvalidOperationException">All tensors must have the same element type</exception>
        /// <exception cref="ArgumentException">
        /// result must be a CPU array - result
        /// or
        /// lhs must be a CPU array - lhs
        /// or
        /// rhs must be a CPU array - rhs
        /// or
        /// lhs must have 2 dimensions - lhs
        /// or
        /// rhs must have 1 dimension (ie. be a vector) - rhs
        /// </exception>
        /// <exception cref="NotSupportedException">CPU Matrix-Vector multiplication with element type " + result.ElementType + " not supported</exception>
        public static ArithArray Mul_M_V(ArithArray result, ArithArray lhs, ArithArray rhs)
        {
            if (lhs.ElementType != rhs.ElementType || (result != null && result.ElementType != lhs.ElementType))
                throw new InvalidOperationException("All tensors must have the same element type");
            if (result != null && (result.Storage is CpuStorage)) throw new ArgumentException("result must be a CPU array", "result");
            if (!(lhs.Storage is CpuStorage)) throw new ArgumentException("lhs must be a CPU array", "lhs");
            if (!(rhs.Storage is CpuStorage)) throw new ArgumentException("rhs must be a CPU array", "rhs");

            if (lhs.DimensionCount != 2) throw new ArgumentException("lhs must have 2 dimensions", "lhs");
            if (rhs.DimensionCount != 1) throw new ArgumentException("rhs must have 1 dimension (ie. be a vector)", "rhs");

            ArithArray lhsClone;
            if (lhs.Strides[1] == 1) // If lhs is already row-major, do nothing
            {
                lhsClone = lhs.CopyRef();
            }
            else if (lhs.Strides[0] == 1) // If lhs is column-major, IntTranspose it
            {
                lhsClone = lhs.IntTranspose();
            }
            else // If lhs is not contiguous in either dimension, make a temporary contiguous copy
            {
                lhsClone = ArrayOps.NewContiguous(lhs);
            }

            var writeTarget = ArrayResultBuilder.GetWriteTarget(result, rhs, false, lhs.Shape[0]);

            try
            {
                if (writeTarget.ElementType == DType.Float32) Run_M_V_float(writeTarget, lhsClone, rhs);
                else if (writeTarget.ElementType == DType.Float64) Run_M_V_double(writeTarget, lhsClone, rhs);
                else
                    throw new NotSupportedException("CPU Matrix-Vector multiplication with element type " + result.ElementType + " not supported");
            }
            finally
            {
                lhsClone.Dispose();
            }

            return writeTarget;
        }

        /// <summary>
        /// Runs the m v float.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="mat">The mat.</param>
        /// <param name="vec">The vec.</param>
        /// <exception cref="ArgumentException">lhs must be contiguous in the last dimension</exception>
        private static void Run_M_V_float(ArithArray result, ArithArray mat, ArithArray vec)
        {
            // Require lhs to be row-major. This means we must tell BLAS to IntTranspose it (BLAS expects column-major matrices)
            if (mat.Strides[1] != 1) throw new ArgumentException("lhs must be contiguous in the last dimension");

            unsafe
            {
                var yPtr = (float*)CpuNativeHelpers.GetBufferStart(result);
                var aPtr = (float*)CpuNativeHelpers.GetBufferStart(mat);
                var xPtr = (float*)CpuNativeHelpers.GetBufferStart(vec);

                byte trans = (byte)'t';
                int m = (int)mat.Shape[1];
                int n = (int)mat.Shape[0];
                int incx = (int)vec.Strides[0];
                int lda = (int)mat.Strides[0];
                int incy = (int)result.Strides[0];
                float alpha = 1;
                float beta = 0;
                OpenBlasNative.sgemv_(&trans, &m, &n, &alpha, aPtr, &lda, xPtr, &incx, &beta, yPtr, &incy);
            }
        }

        /// <summary>
        /// Runs the m v double.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <exception cref="ArgumentException">lhs must be contiguous in the last dimension</exception>
        private static void Run_M_V_double(ArithArray result, ArithArray lhs, ArithArray rhs)
        {
            // Require lhs to be row-major. This means we must tell BLAS to IntTranspose it (BLAS expects column-major matrices)
            if (lhs.Strides[1] != 1) throw new ArgumentException("lhs must be contiguous in the last dimension");

            unsafe
            {
                var resultPtr = (double*)CpuNativeHelpers.GetBufferStart(result);
                var lhsPtr = (double*)CpuNativeHelpers.GetBufferStart(lhs);
                var rhsPtr = (double*)CpuNativeHelpers.GetBufferStart(rhs);

                byte trans = (byte)'t';
                int m = (int)rhs.Shape[1];
                int n = (int)lhs.Shape[0];
                int lda = (int)rhs.Strides[0];
                int ldb = (int)lhs.Strides[0];
                int ldc = (int)result.Strides[0];
                double alpha = 1;
                double beta = 0;
                OpenBlasNative.dgemv_(&trans, &m, &n, &alpha, rhsPtr, &lda, lhsPtr, &ldb, &beta, resultPtr, &ldc);
            }
        }



        /// <summary>
        /// Muls the m m.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        /// <exception cref="InvalidOperationException">All tensors must have the same element type</exception>
        /// <exception cref="ArgumentException">
        /// result must be a CPU array - result
        /// or
        /// lhs must be a CPU array - lhs
        /// or
        /// rhs must be a CPU array - rhs
        /// </exception>
        public static ArithArray Mul_M_M(ArithArray result, ArithArray lhs, ArithArray rhs)
        {
            if (lhs.ElementType != rhs.ElementType || (result != null && result.ElementType != lhs.ElementType))
                throw new InvalidOperationException("All tensors must have the same element type");
            if (result != null && !(result.Storage is CpuStorage)) throw new ArgumentException("result must be a CPU array", "result");
            if (!(lhs.Storage is CpuStorage)) throw new ArgumentException("lhs must be a CPU array", "lhs");
            if (!(rhs.Storage is CpuStorage)) throw new ArgumentException("rhs must be a CPU array", "rhs");

            var writeTarget = ArrayResultBuilder.GetWriteTarget(result, lhs, false, lhs.Shape[0], rhs.Shape[1]);
            
            Gemm(1, lhs, rhs, 0, writeTarget);
            

            return writeTarget;
        }

        // Computes  c := alpha * a * b  +  beta * c
        /// <summary>
        /// Gemms the specified alpha.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="c">The c.</param>
        /// <exception cref="InvalidOperationException">Size mismatch</exception>
        public static void Gemm(float alpha, ArithArray a, ArithArray b, float beta, ArithArray c)
        {
            if (a.Shape[0] != c.Shape[0] || b.Shape[1] != c.Shape[1] || a.Shape[1] != b.Shape[0])
                throw new InvalidOperationException("Size mismatch");

            BlasOp aOp = default(BlasOp);
            BlasOp bOp = default(BlasOp);
            bool copyC = false;

            ArithArray aClone = null;
            ArithArray bClone = null;
            ArithArray cClone = null;


            if (c.Strides[0] == 1 &&
                c.Strides[1] != 0)
            {
                // If c is contiguous in dimension 0 (column-major)
                aClone = a.CopyRef();
                bClone = b.CopyRef();
                cClone = c.CopyRef();
            }
            else if (c.Strides[1] == 1 &&
                c.Strides[0] != 0)
            {
                // If c is contiguous in dimension 1 (row-major)
                // using (a * b)' == b' * a'
                // we can pass row-major matrices to BLAS functions that expect column-major by swapping A and B,
                // and transposing all 3 matrices

                cClone = c.IntTranspose();
                aClone = b.IntTranspose(); // Note swap of a and b
                bClone = a.IntTranspose();
            }
            else
            {
                var cNew = new ArithArray(new long[] { c.Shape[1], c.Shape[0] }, c.ElementType);
                cClone = cNew.IntTranspose();
                ArrayOps.Copy(cClone, c);
                cNew.Dispose();
                copyC = true;

                aClone = a.CopyRef();
                bClone = b.CopyRef();
            }

            try
            {
                if (aClone.Strides[0] == 1 &&
                    aClone.Strides[1] != 0)
                {
                    // If a is contiguous in dimension 0 (column-major)
                    aOp = BlasOp.NonTranspose;
                }
                else if (aClone.Strides[1] == 1 &&
                    aClone.Strides[0] != 0)
                {
                    aOp = BlasOp.Transpose;
                    var aNew = aClone.IntTranspose();
                    aClone.Dispose();
                    aClone = aNew;
                }
                else
                {
                    var aNew = new ArithArray(new long[] { aClone.Shape[1], aClone.Shape[0] }, aClone.ElementType);
                    var aClone2 = aNew.IntTranspose();
                    ArrayOps.Copy(aClone2, aClone);
                    aClone.Dispose();
                    aClone = aClone2;
                    aNew.Dispose();
                }

                if (bClone.Strides[0] == 1 &&
                    bClone.Strides[1] != 0)
                {
                    // If b is contiguous in dimension 0 (column-major)
                    bOp = BlasOp.NonTranspose;
                }
                else if (bClone.Strides[1] == 1 &&
                    bClone.Strides[0] != 0)
                {
                    bOp = BlasOp.Transpose;
                    var bNew = bClone.IntTranspose();
                    bClone.Dispose();
                    bClone = bNew;
                }
                else
                {
                    var bNew = new ArithArray(new long[] { bClone.Shape[1], bClone.Shape[0] }, bClone.ElementType);
                    var bClone2 = bNew.IntTranspose();
                    ArrayOps.Copy(bClone2, bClone);
                    bClone.Dispose();
                    bClone = bClone2;
                    bNew.Dispose();
                }

                GemmOp(aOp, bOp, alpha, aClone, bClone, beta, cClone);

                if (copyC)
                {
                    ArrayOps.Copy(c, cClone);
                }
            }
            finally
            {
                aClone.Dispose();
                bClone.Dispose();
                cClone.Dispose();
            }
        }


        /// <summary>
        /// Gemms the op.
        /// </summary>
        /// <param name="transA">The trans a.</param>
        /// <param name="transB">The trans b.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="c">The c.</param>
        /// <exception cref="ArgumentException">
        /// a must be contiguous in the first dimension (column major / fortran order)
        /// or
        /// b must be contiguous in the first dimension (column major / fortran order)
        /// or
        /// c must be contiguous in the first dimension (column major / fortran order)
        /// </exception>
        /// <exception cref="NotSupportedException">CPU GEMM with element type " + c.ElementType + " not supported</exception>
        private static void GemmOp(BlasOp transA, BlasOp transB, float alpha, ArithArray a, ArithArray b, float beta, ArithArray c)
        {
            if (a.Strides[0] != 1) throw new ArgumentException("a must be contiguous in the first dimension (column major / fortran order)");
            if (b.Strides[0] != 1) throw new ArgumentException("b must be contiguous in the first dimension (column major / fortran order)");
            if (c.Strides[0] != 1) throw new ArgumentException("c must be contiguous in the first dimension (column major / fortran order)");

            unsafe
            {
                // dimensons: (m x k) * (k * n) = (m x n)
                bool nta = transA == BlasOp.NonTranspose;
                bool ntb = transB == BlasOp.NonTranspose;
                byte transa = (byte)transA;
                byte transb = (byte)transB;
                int m = (int)a.Shape[nta ? 0 : 1];
                int k = (int)b.Shape[ntb ? 0 : 1];
                int n = (int)b.Shape[ntb ? 1 : 0];
                int lda = (int)a.Strides[1];
                int ldb = (int)b.Strides[1];
                int ldc = (int)c.Strides[1];

                if (c.ElementType == DType.Float32)
                {
                    var aPtrSingle = (float*)CpuNativeHelpers.GetBufferStart(a);
                    var bPtrSingle = (float*)CpuNativeHelpers.GetBufferStart(b);
                    var cPtrSingle = (float*)CpuNativeHelpers.GetBufferStart(c);

                    OpenBlasNative.sgemm_(&transa, &transb, &m, &n, &k, &alpha, aPtrSingle, &lda, bPtrSingle, &ldb, &beta, cPtrSingle, &ldc);
                }
                else if (c.ElementType == DType.Float64)
                {
                    var aPtrDouble = (double*)CpuNativeHelpers.GetBufferStart(a);
                    var bPtrDouble = (double*)CpuNativeHelpers.GetBufferStart(b);
                    var cPtrDouble = (double*)CpuNativeHelpers.GetBufferStart(c);
                    var alphaDouble = (double)alpha;
                    var betaDouble = (double)beta;
                    OpenBlasNative.dgemm_(&transa, &transb, &m, &n, &k, &alphaDouble, aPtrDouble, &lda, bPtrDouble, &ldb, &betaDouble, cPtrDouble, &ldc);
                }
                else
                {
                    throw new NotSupportedException("CPU GEMM with element type " + c.ElementType + " not supported");
                }
            }
        }
    }
}
