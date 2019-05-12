// ***********************************************************************
// Assembly         : Arithmetica
// Author           : Community
// Created          : 12-09-2018
//
// Last Modified By : Deepak Battini
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="TOps.cs" company="Arithmetica">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arithmetica.Core;

namespace Arithmetica
{
    /// <summary>
    /// Class TOps.
    /// </summary>
    internal class ArrayOps
    {
        [NonSerialized]
        public float EPSILON = 1e-07f;

        /// <summary>
        /// Creates new contiguous.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray NewContiguous(ArithArray src)
        {
            var result = new ArithArray((long[])src.Shape.Clone(), src.ElementType);
            Copy(result, src);
            return result;
        }

        /// <summary>
        /// Ases the contiguous.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray AsContiguous(ArithArray src)
        {
            if (src.IsContiguous())
                return src.CopyRef();
            else
                return NewContiguous(src);
        }

        /// <summary>
        /// Concats the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="inputs">The inputs.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Concat( int dimension, params ArithArray[] inputs)
        {
            return ArrayConcat.Concat(null, dimension, inputs);
        }

        /// <summary>
        /// Fills the one hot.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="labelCount">The label count.</param>
        /// <param name="labels">The labels.</param>
        public static void FillOneHot(ArithArray src, int labelCount, int[] labels)
        {
            if (src.Storage is Cpu.CpuStorage)
            {
                DoFillOneHot(src, labelCount, labels);
            }
            else
            {
                //If the result is not on the CPU, it is much faster to build the array on the CPU and then copy
                //An alternative to this would be building a specific GPU kernel for this operation
                var cpuAlloc = new Cpu.CpuAllocator();
                using (var cpuResult = new ArithArray(src.Shape, src.ElementType))
                {
                    DoFillOneHot(cpuResult, labelCount, labels);
                    ArrayOps.Copy(src, cpuResult);
                }
            }
        }

        /// <summary>
        /// Does the fill one hot.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="labelCount">The label count.</param>
        /// <param name="labels">The labels.</param>
        /// <exception cref="InvalidOperationException">
        /// result must be a 2D array
        /// or
        /// first dimension of result must equal the number of samples
        /// or
        /// second dimension of result must be at least as large as labelCount
        /// or
        /// label at index " + i + " is out of range 0 <= x < labelCount
        /// </exception>
        private static void DoFillOneHot(ArithArray src, int labelCount, int[] labels)
        {
            if (src.DimensionCount != 2) throw new InvalidOperationException("result must be a 2D array");
            if (src.Shape[0] != labels.Length) throw new InvalidOperationException("first dimension of result must equal the number of samples");
            if (src.Shape[1] > labelCount) throw new InvalidOperationException("second dimension of result must be at least as large as labelCount");

            ArrayOps.Fill(src, 0);
            for (int i = 0; i < labels.Length; ++i)
            {
                if (labels[i] < 0 || labels[i] >= labelCount)
                    throw new InvalidOperationException("label at index " + i + " is out of range 0 <= x < labelCount");

                src.SetElementAsFloat(1.0f, i, labels[i]);
            }
        }


        /// <summary>
        /// Copies the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        public static void Copy(ArithArray result, ArithArray src) { OpRegistry.Invoke("copy", result, src); }

        /// <summary>
        /// Fills the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="value">The value.</param>
        public static void Fill(ArithArray src, float value) { OpRegistry.Invoke("fill", src, value); }

        /// <summary>
        /// Dots the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Dot( ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("dot", null, lhs, rhs); }
        /// <summary>
        /// Addmms the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="src">The source.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Addmm( float beta, ArithArray src, float alpha, ArithArray m1, ArithArray m2) { return (ArithArray)OpRegistry.Invoke("addmm", null, beta, src, alpha, m1, m2); }

        /// <summary>
        /// Abses the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Abs( ArithArray src) { return (ArithArray)OpRegistry.Invoke("abs", null, src); }

        /// <summary>
        /// Negs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Neg( ArithArray src) { return (ArithArray)OpRegistry.Invoke("neg", null, src); }

        /// <summary>
        /// Signs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sign( ArithArray src) { return (ArithArray)OpRegistry.Invoke("sign", null, src); }

        /// <summary>
        /// SQRTs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sqrt( ArithArray src) { return (ArithArray)OpRegistry.Invoke("sqrt", null, src); }
        /// <summary>
        /// Exps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Exp( ArithArray src) { return (ArithArray)OpRegistry.Invoke("exp", null, src); }
        /// <summary>
        /// Logs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Log( ArithArray src) { return (ArithArray)OpRegistry.Invoke("log", null, src); }
        /// <summary>
        /// Log1ps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Log1p( ArithArray src) { return (ArithArray)OpRegistry.Invoke("log1p", null, src); }
        /// <summary>
        /// Floors the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Floor( ArithArray src) { return (ArithArray)OpRegistry.Invoke("floor", null, src); }
        /// <summary>
        /// Ceils the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Ceil( ArithArray src) { return (ArithArray)OpRegistry.Invoke("ceil", null, src); }
        /// <summary>
        /// Rounds the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Round( ArithArray src) { return (ArithArray)OpRegistry.Invoke("round", null, src); }
        /// <summary>
        /// Truncs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Trunc( ArithArray src) { return (ArithArray)OpRegistry.Invoke("trunc", null, src); }
        /// <summary>
        /// Fracs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Frac( ArithArray src) { return (ArithArray)OpRegistry.Invoke("frac", null, src); }

        /// <summary>
        /// Sins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sin(ArithArray src) { return (ArithArray)OpRegistry.Invoke("sin", null, src); }
        /// <summary>
        /// Coses the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Cos( ArithArray src) { return (ArithArray)OpRegistry.Invoke("cos", null, src); }
        /// <summary>
        /// Tans the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Tan( ArithArray src) { return (ArithArray)OpRegistry.Invoke("tan", null, src); }

        /// <summary>
        /// Asins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Asin( ArithArray src) { return (ArithArray)OpRegistry.Invoke("asin", null, src); }
        /// <summary>
        /// Acoses the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Acos( ArithArray src) { return (ArithArray)OpRegistry.Invoke("acos", null, src); }
        /// <summary>
        /// Atans the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Atan( ArithArray src) { return (ArithArray)OpRegistry.Invoke("atan", null, src); }

        /// <summary>
        /// Sinhes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sinh( ArithArray src) { return (ArithArray)OpRegistry.Invoke("sinh", null, src); }
        /// <summary>
        /// Coshes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Cosh( ArithArray src) { return (ArithArray)OpRegistry.Invoke("cosh", null, src); }
        /// <summary>
        /// Tanhes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Tanh( ArithArray src) { return (ArithArray)OpRegistry.Invoke("tanh", null, src); }

        /// <summary>
        /// Sigmoids the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sigmoid( ArithArray src) { return (ArithArray)OpRegistry.Invoke("sigmoid", null, src); }


        /// <summary>
        /// Atan2s the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="srcY">The source y.</param>
        /// <param name="srcX">The source x.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Atan2( ArithArray srcY, ArithArray srcX) { return (ArithArray)OpRegistry.Invoke("atan2", null, srcY, srcX); }
        /// <summary>
        /// Pows the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Pow( ArithArray src, float value) { return (ArithArray)OpRegistry.Invoke("pow", null, src, value); }

        /// <summary>
        /// Squares the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Square(ArithArray src) { return (ArithArray)OpRegistry.Invoke("pow", null, src, 2); }

        /// <summary>
        /// Tpows the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="value">The value.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Tpow( float value, ArithArray src) { return (ArithArray)OpRegistry.Invoke("tpow", null, value, src); }


        /// <summary>
        /// Lerps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="srcA">The source a.</param>
        /// <param name="srcB">The source b.</param>
        /// <param name="weight">The weight.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Lerp( ArithArray srcA, ArithArray srcB, float weight) { return (ArithArray)OpRegistry.Invoke("lerp", null, srcA, srcB); }
        /// <summary>
        /// Clamps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Clip( ArithArray src, float min, float max) { return (ArithArray)OpRegistry.Invoke("clamp", null, src, min, max); }


        /// <summary>
        /// Adds the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Add( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("addv", null, lhs, rhs); }
        /// <summary>
        /// Subs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sub( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("subv", null, lhs, rhs); }
        /// <summary>
        /// Subs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sub( float lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("rsubv", null, lhs, rhs); }
        /// <summary>
        /// Muls the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Mul( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("mulv", null, lhs, rhs); }
        /// <summary>
        /// Divs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Div( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("divv", null, lhs, rhs); }
        /// <summary>
        /// Divs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Div( float lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("rdivv", null, lhs, rhs); }
        /// <summary>
        /// Mods the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Mod( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("modv", null, lhs, rhs); }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray GreaterThan( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("gtValue", null, lhs, rhs); }
        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray LessThan( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("ltValue", null, lhs, rhs); }
        /// <summary>
        /// Greaters the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray GreaterOrEqual( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("geValue", null, lhs, rhs); }
        /// <summary>
        /// Lesses the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray LessOrEqual( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("leValue", null, lhs, rhs); }
        /// <summary>
        /// Equals to.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray EqualTo( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("eqValue", null, lhs, rhs); }
        /// <summary>
        /// Nots the equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray NotEqual( ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("neValue", null, lhs, rhs); }

        /// <summary>
        /// Adds the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Add(ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("addt", null, lhs, rhs); }
        /// <summary>
        /// Subs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sub(ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("subt", null, lhs, rhs); }
        /// <summary>
        /// Muls the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Mul(ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("mult", null, lhs, rhs); }
        /// <summary>
        /// Divs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Div(ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("divt", null, lhs, rhs); }
        /// <summary>
        /// Mods the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Mod(ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("modt", null, lhs, rhs); }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray GreaterThan( ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("gtTensor", null, lhs, rhs); }
        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray LessThan( ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("ltTensor", null, lhs, rhs); }
        /// <summary>
        /// Greaters the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray GreaterOrEqual( ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("geTensor", null, lhs, rhs); }
        /// <summary>
        /// Lesses the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray LessOrEqual( ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("leTensor", null, lhs, rhs); }
        /// <summary>
        /// Equals to.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray EqualTo( ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("eqTensor", null, lhs, rhs); }
        /// <summary>
        /// Nots the equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray NotEqual( ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("neTensor", null, lhs, rhs); }


        /// <summary>
        /// Sums the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sum(ArithArray src, int dimension)
        {
            dimension = dimension < 0 ? src.DimensionCount + dimension : dimension;
            return (ArithArray)OpRegistry.Invoke("sum", null, src, dimension);
        }

        public static ArithArray Sum(ArithArray src, params int[] dimension)
        {
            foreach (int dim in dimension)
            {
                src = Sum(src, dim);
            }

            return src;
        }

        /// <summary>
        /// Products the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Prod( ArithArray src, int dimension) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (ArithArray)OpRegistry.Invoke("prod", null, src, dimension); }
        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Min( ArithArray src, int dimension) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (ArithArray)OpRegistry.Invoke("min", null, src, dimension); }
        /// <summary>
        /// Determines the maximun of the parameters.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Max( ArithArray src, int dimension)
        {
            dimension = dimension < 0 ? src.DimensionCount + dimension : dimension;

            return (ArithArray)OpRegistry.Invoke("max", null, src, dimension);
        }

        public static ArithArray Max(ArithArray src, params int[] dimension)
        {
            var shape = src.Shape;
            
            foreach (var item in dimension)
            {
                src = Max(src, item);
            }

            return src;
        }

        /// <summary>
        /// Argmins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Argmin(ArithArray src, int dimension) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (ArithArray)OpRegistry.Invoke("argmin", null, src, dimension); }
        /// <summary>
        /// Argmaxes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Argmax(ArithArray src, int dimension) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (ArithArray)OpRegistry.Invoke("argmax", null, src, dimension); }

        /// <summary>
        /// Means the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Mean(ArithArray src, int dimension)
        {
            dimension = dimension < 0 ? src.DimensionCount + dimension : dimension;

            return (ArithArray)OpRegistry.Invoke("mean", null, src, dimension);
        }

        public static ArithArray Mean(ArithArray src, params int[] dimension)
        {
            foreach (var item in dimension)
            {
                src = Mean(src, item);
            }

            return src;
        }

        /// <summary>
        /// Norms the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="value">The value.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Norm( ArithArray src, int dimension, float value) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (ArithArray)OpRegistry.Invoke("norm", null, src, dimension, value); }
        /// <summary>
        /// Standards the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Std( ArithArray src, int dimension, bool normByN) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (ArithArray)OpRegistry.Invoke("std", null, src, dimension, normByN); }
        /// <summary>
        /// Variables the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Var( ArithArray src, int dimension, bool normByN) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (ArithArray)OpRegistry.Invoke("var", null, src, dimension, normByN); }

        /// <summary>
        /// Sums all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Sum( ArithArray src) { return (ArithArray)OpRegistry.Invoke("sumall", null, src); }
        /// <summary>
        /// Products all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Prod( ArithArray src) { return (ArithArray)OpRegistry.Invoke("prodall", null, src); }
        /// <summary>
        /// Minimums all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Min( ArithArray src) { return (ArithArray)OpRegistry.Invoke("minall", null, src); }
        /// <summary>
        /// Maximums all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Max( ArithArray src) { return (ArithArray)OpRegistry.Invoke("maxall", null, src); }

        /// <summary>
        /// Means all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Mean( ArithArray src) { return (ArithArray)OpRegistry.Invoke("meanall", null, src); }
        /// <summary>
        /// Norms all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Norm( ArithArray src, float value) { return (ArithArray)OpRegistry.Invoke("normall", null, src, value); }
        /// <summary>
        /// Standards all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Std( ArithArray src) { return (ArithArray)OpRegistry.Invoke("stdall", null, src); }
        /// <summary>
        /// Variables all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Var( ArithArray src) { return (ArithArray)OpRegistry.Invoke("varall", null, src); }


        /// <summary>
        /// Sums all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float SumF(ArithArray src) { using (var resultTensor = Sum(src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Products all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float ProdF(ArithArray src) { using (var resultTensor = Prod(src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Minimums all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float MinF(ArithArray src) { using (var resultTensor = Min(src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Maximums all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float MaxF(ArithArray src) { using (var resultTensor = Max(src)) { return resultTensor.GetElementAsFloat(0); } }

        /// <summary>
        /// Means all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float MeanF(ArithArray src) { using (var resultTensor = Mean(src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Variables all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float VarF(ArithArray src) { using (var resultTensor = Var(src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Standards all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float StdF(ArithArray src) { using (var resultTensor = Std(src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Norms all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        public static float NormF(ArithArray src, float value) { using (var resultTensor = Norm(src, value)) { return resultTensor.GetElementAsFloat(0); } }


        /// <summary>
        /// Indexes the select.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray IndexSelect( ArithArray src, int dim, ArithArray indices) { return (ArithArray)OpRegistry.Invoke("index_select", null, src, dim, indices); }
        /// <summary>
        /// Gathers the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Gather( ArithArray src, int dim, ArithArray indices) { return (ArithArray)OpRegistry.Invoke("gather", null, src, dim, indices); }
        /// <summary>
        /// Scatters the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray Scatter( ArithArray src, int dim, ArithArray indices)
        {
            var result = src;
            result = (ArithArray)OpRegistry.Invoke("scatter", result, src, dim, indices);
            return result;
        }
        /// <summary>
        /// Scatters the fill.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="value">The value.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>ArithArray.</returns>
        public static ArithArray ScatterFill( float value, int dim, ArithArray indices) { return (ArithArray)OpRegistry.Invoke("scatter_fill", null, value, dim, indices); }


        public static ArithArray Maximum(ArithArray a, ArithArray b)
        {
            var t1 = (a >= b);
            var t2 = (a > b);

            return (t1 * a + t2 * b);
        }

        public static ArithArray Maximum(ArithArray a, float b)
        {
            var b_t = new ArithArray(a.Shape, a.ElementType);
            ArrayOps.Fill(b_t, b);
            return Maximum(a, b_t);
        }

        public static ArithArray Maximum(float a, ArithArray b)
        {
            var a_t = new ArithArray(b.Shape, b.ElementType);
            ArrayOps.Fill(a_t, a);
            return Maximum(a_t, b);
        }

        public static ArithArray Softplus(ArithArray x)
        {
            return Log((Exp(x) + 1));
        }

        public static ArithArray Softmax(ArithArray x, int axis=-1)
        {
            var e = Exp(x - Max(x, axis));
            var s = Sum(e, axis);
            return e / s;
        }

        public static ArithArray L2Normalize(ArithArray x, int axis = -1)
        {
            ArithArray y = Max(Sum(Square(x), axis), axis);

            return x / Sqrt(y);
        }

        public static ArithArray Tile(ArithArray x, long repetitions)
        {
            long[] shape = new long[x.DimensionCount];
            for (int i = 0; i < shape.Length; i++)
            {
                shape[i] = 1;
            }

            shape[shape.Length - 1] = repetitions;

            return x.RepeatTensor(shape);
        }

        public static ArithArray Repeat(ArithArray x, int reps)
        {
            x = x.View(x.ElementCount(), 1).Tile(reps);
            return x.View(1, x.ElementCount());
        }

        public static ArithArray Diag(ArithArray x)
        {
            return (ArithArray)OpRegistry.Invoke("diag", x);
        }

        public static ValueTuple<ArithArray, ArithArray> BroadcastTensor(ArithArray lhs, ArithArray rhs)
        {
            if (!lhs.IsSameSizeAs(rhs))
            {
                if (lhs.Shape[0] == rhs.Shape[0] && (lhs.Shape[1] == 1 || rhs.Shape[1] == 1))
                {
                    if (lhs.Shape[1] == 1)
                    {
                        lhs = lhs.RepeatTensor(1, rhs.Shape[1]);
                    }

                    if (rhs.Shape[1] == 1)
                    {
                        rhs = rhs.RepeatTensor(1, lhs.Shape[1]);
                    }
                }

                if (lhs.Shape[1] == rhs.Shape[1] && (lhs.Shape[0] == 1 || rhs.Shape[0] == 1))
                {
                    if (lhs.Shape[0] == 1)
                    {
                        lhs = lhs.RepeatTensor(rhs.Shape[0], 1);
                    }

                    if (rhs.Shape[0] == 1)
                    {
                        rhs = rhs.RepeatTensor(lhs.Shape[0], 1);
                    }
                }

                if (lhs.Shape[1] == 1 && rhs.Shape[0] == 1)
                {
                    if (lhs.Shape[1] == 1)
                    {
                        lhs = lhs.RepeatTensor(1, rhs.Shape[1]);
                    }

                    if (rhs.Shape[0] == 1)
                    {
                        rhs = rhs.RepeatTensor(lhs.Shape[0], 1);
                    }
                }

                if (lhs.Shape[0] == 1 || rhs.Shape[1] == 1)
                {
                    if (lhs.Shape[0] == 1)
                    {
                        lhs = lhs.RepeatTensor(rhs.Shape[0], 1);
                    }

                    if (rhs.Shape[1] == 1)
                    {
                        rhs = rhs.RepeatTensor(1, lhs.Shape[1]);
                    }
                }
            }

            return (lhs, rhs);
        }

        /// <summary>
        /// Gets the seed.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        private static int? GetSeed(SeedSource src)
        {
            return src == null ? (int?)null : src.NextSeed();
        }

        /// <summary>
        /// Randoms the uniform.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public static void RandomUniform(ArithArray result, SeedSource seedSource, float min, float max) { OpRegistry.Invoke("random_uniform", result, GetSeed(seedSource), min, max); }
        /// <summary>
        /// Randoms the normal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="mean">The mean.</param>
        /// <param name="stdv">The STDV.</param>
        public static void RandomNormal(ArithArray result, SeedSource seedSource, float mean, float stdv) { OpRegistry.Invoke("random_normal", result, GetSeed(seedSource), mean, stdv); }
        /// <summary>
        /// Randoms the exponential.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="lambda">The lambda.</param>
        public static void RandomExponential(ArithArray result, SeedSource seedSource, float lambda) { OpRegistry.Invoke("random_exponential", result, GetSeed(seedSource), lambda); }
        /// <summary>
        /// Randoms the cauchy.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="median">The median.</param>
        /// <param name="sigma">The sigma.</param>
        public static void RandomCauchy(ArithArray result, SeedSource seedSource, float median, float sigma) { OpRegistry.Invoke("random_cauchy", result, GetSeed(seedSource), median, sigma); }
        /// <summary>
        /// Randoms the log normal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="mean">The mean.</param>
        /// <param name="stdv">The STDV.</param>
        public static void RandomLogNormal(ArithArray result, SeedSource seedSource, float mean, float stdv) { OpRegistry.Invoke("random_lognormal", result, GetSeed(seedSource), mean, stdv); }
        /// <summary>
        /// Randoms the geometric.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="p">The p.</param>
        public static void RandomGeometric(ArithArray result, SeedSource seedSource, float p) { OpRegistry.Invoke("random_geometric", result, GetSeed(seedSource), p); }
        /// <summary>
        /// Randoms the bernoulli.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="p">The p.</param>
        public static void RandomBernoulli(ArithArray result, SeedSource seedSource, float p) { OpRegistry.Invoke("random_bernoulli", result, GetSeed(seedSource), p); }


    }
}
