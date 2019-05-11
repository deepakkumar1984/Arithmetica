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
    public static class Ops112
    {
        /// <summary>
        /// Creates new contiguous.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
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
        /// <returns>Tensor.</returns>
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
        /// <returns>Tensor.</returns>
        public static ArithArray Concat(ArithArray result, int dimension, params ArithArray[] inputs)
        {
            return ArrayConcat.Concat(result, dimension, inputs);
        }

        /// <summary>
        /// Fills the one hot.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="labelCount">The label count.</param>
        /// <param name="labels">The labels.</param>
        public static void FillOneHot(ArithArray result, int labelCount, int[] labels)
        {
            if (result.Storage is Cpu.CpuStorage)
            {
                DoFillOneHot(result, labelCount, labels);
            }
            else
            {
                //If the result is not on the CPU, it is much faster to build the array on the CPU and then copy
                //An alternative to this would be building a specific GPU kernel for this operation
                var cpuAlloc = new Cpu.CpuAllocator();
                using (var cpuResult = new ArithArray(result.Shape, result.ElementType))
                {
                    DoFillOneHot(cpuResult, labelCount, labels);
                    ArrayOps.Copy(result, cpuResult);
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
        private static void DoFillOneHot(ArithArray result, int labelCount, int[] labels)
        {
            if (result.DimensionCount != 2) throw new InvalidOperationException("result must be a 2D array");
            if (result.Shape[0] != labels.Length) throw new InvalidOperationException("first dimension of result must equal the number of samples");
            if (result.Shape[1] > labelCount) throw new InvalidOperationException("second dimension of result must be at least as large as labelCount");

            ArrayOps.Fill(result, 0);
            for (int i = 0; i < labels.Length; ++i)
            {
                if (labels[i] < 0 || labels[i] >= labelCount)
                    throw new InvalidOperationException("label at index " + i + " is out of range 0 <= x < labelCount");

                result.SetElementAsFloat(1.0f, i, labels[i]);
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
        public static void Fill(ArithArray result, float value) { OpRegistry.Invoke("fill", result, value); }

        /// <summary>
        /// Dots the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Dot(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("dot", result, lhs, rhs); }
        /// <summary>
        /// Addmms the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="src">The source.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Addmm(ArithArray result, float beta, ArithArray src, float alpha, ArithArray m1, ArithArray m2) { return (ArithArray)OpRegistry.Invoke("addmm", result, beta, src, alpha, m1, m2); }

        /// <summary>
        /// Abses the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Abs(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("abs", result, src); }

        /// <summary>
        /// Negs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Neg(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("neg", result, src); }

        /// <summary>
        /// Signs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sign(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("sign", result, src); }

        /// <summary>
        /// SQRTs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sqrt(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("sqrt", result, src); }
        /// <summary>
        /// Exps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Exp(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("exp", result, src); }
        /// <summary>
        /// Logs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Log(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("log", result, src); }
        /// <summary>
        /// Log1ps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Log1p(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("log1p", result, src); }
        /// <summary>
        /// Floors the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Floor(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("floor", result, src); }
        /// <summary>
        /// Ceils the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Ceil(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("ceil", result, src); }
        /// <summary>
        /// Rounds the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Round(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("round", result, src); }
        /// <summary>
        /// Truncs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Trunc(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("trunc", result, src); }
        /// <summary>
        /// Fracs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Frac(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("frac", result, src); }

        /// <summary>
        /// Sins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sin(ArithArray src) { return (ArithArray)OpRegistry.Invoke("sin", null, src); }
        /// <summary>
        /// Coses the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Cos(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("cos", result, src); }
        /// <summary>
        /// Tans the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Tan(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("tan", result, src); }

        /// <summary>
        /// Asins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Asin(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("asin", result, src); }
        /// <summary>
        /// Acoses the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Acos(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("acos", result, src); }
        /// <summary>
        /// Atans the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Atan(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("atan", result, src); }

        /// <summary>
        /// Sinhes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sinh(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("sinh", result, src); }
        /// <summary>
        /// Coshes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Cosh(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("cosh", result, src); }
        /// <summary>
        /// Tanhes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Tanh(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("tanh", result, src); }

        /// <summary>
        /// Sigmoids the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sigmoid(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("sigmoid", result, src); }


        /// <summary>
        /// Atan2s the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="srcY">The source y.</param>
        /// <param name="srcX">The source x.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Atan2(ArithArray result, ArithArray srcY, ArithArray srcX) { return (ArithArray)OpRegistry.Invoke("atan2", result, srcY, srcX); }
        /// <summary>
        /// Pows the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Pow(ArithArray result, ArithArray src, float value) { return (ArithArray)OpRegistry.Invoke("pow", result, src, value); }
        /// <summary>
        /// Tpows the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="value">The value.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Tpow(ArithArray result, float value, ArithArray src) { return (ArithArray)OpRegistry.Invoke("tpow", result, value, src); }
        /// <summary>
        /// Lerps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="srcA">The source a.</param>
        /// <param name="srcB">The source b.</param>
        /// <param name="weight">The weight.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Lerp(ArithArray result, ArithArray srcA, ArithArray srcB, float weight) { return (ArithArray)OpRegistry.Invoke("lerp", result, srcA, srcB); }
        /// <summary>
        /// Clamps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Clamp(ArithArray result, ArithArray src, float min, float max) { return (ArithArray)OpRegistry.Invoke("clamp", result, src, min, max); }


        /// <summary>
        /// Adds the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Add(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("addv", result, lhs, rhs); }
        /// <summary>
        /// Subs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sub(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("subv", result, lhs, rhs); }
        /// <summary>
        /// Subs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sub(ArithArray result, float lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("rsubv", result, lhs, rhs); }
        /// <summary>
        /// Muls the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Mul(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("mulv", result, lhs, rhs); }
        /// <summary>
        /// Divs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Div(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("divv", result, lhs, rhs); }
        /// <summary>
        /// Divs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Div(ArithArray result, float lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("rdivv", result, lhs, rhs); }
        /// <summary>
        /// Mods the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Mod(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("modv", result, lhs, rhs); }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray GreaterThan(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("gtValue", result, lhs, rhs); }
        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray LessThan(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("ltValue", result, lhs, rhs); }
        /// <summary>
        /// Greaters the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray GreaterOrEqual(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("geValue", result, lhs, rhs); }
        /// <summary>
        /// Lesses the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray LessOrEqual(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("leValue", result, lhs, rhs); }
        /// <summary>
        /// Equals to.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray EqualTo(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("eqValue", result, lhs, rhs); }
        /// <summary>
        /// Nots the equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray NotEqual(ArithArray result, ArithArray lhs, float rhs) { return (ArithArray)OpRegistry.Invoke("neValue", result, lhs, rhs); }

        /// <summary>
        /// Adds the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Add(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("addt", result, lhs, rhs); }
        /// <summary>
        /// Subs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sub(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("subt", result, lhs, rhs); }
        /// <summary>
        /// Muls the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Mul(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("mult", result, lhs, rhs); }
        /// <summary>
        /// Divs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Div(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("divt", result, lhs, rhs); }
        /// <summary>
        /// Mods the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Mod(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("modt", result, lhs, rhs); }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray GreaterThan(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("gtTensor", result, lhs, rhs); }
        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray LessThan(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("ltTensor", result, lhs, rhs); }
        /// <summary>
        /// Greaters the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray GreaterOrEqual(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("geTensor", result, lhs, rhs); }
        /// <summary>
        /// Lesses the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray LessOrEqual(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("leTensor", result, lhs, rhs); }
        /// <summary>
        /// Equals to.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray EqualTo(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("eqTensor", result, lhs, rhs); }
        /// <summary>
        /// Nots the equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray NotEqual(ArithArray result, ArithArray lhs, ArithArray rhs) { return (ArithArray)OpRegistry.Invoke("neTensor", result, lhs, rhs); }


        /// <summary>
        /// Sums the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Sum(ArithArray result, ArithArray src, int dimension) { return (ArithArray)OpRegistry.Invoke("sum", result, src, dimension); }
        /// <summary>
        /// Products the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Prod(ArithArray result, ArithArray src, int dimension) { return (ArithArray)OpRegistry.Invoke("prod", result, src, dimension); }
        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Min(ArithArray result, ArithArray src, int dimension) { return (ArithArray)OpRegistry.Invoke("min", result, src, dimension); }
        /// <summary>
        /// Determines the maximun of the parameters.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Max(ArithArray result, ArithArray src, int dimension) { return (ArithArray)OpRegistry.Invoke("max", result, src, dimension); }
        /// <summary>
        /// Argmins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Argmin(ArithArray result, ArithArray src, int dimension) { return (ArithArray)OpRegistry.Invoke("argmin", result, src, dimension); }
        /// <summary>
        /// Argmaxes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Argmax(ArithArray result, ArithArray src, int dimension) { return (ArithArray)OpRegistry.Invoke("argmax", result, src, dimension); }

        /// <summary>
        /// Means the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Mean(ArithArray result, ArithArray src, int dimension) { return (ArithArray)OpRegistry.Invoke("mean", result, src, dimension); }
        /// <summary>
        /// Norms the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="value">The value.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Norm(ArithArray result, ArithArray src, int dimension, float value) { return (ArithArray)OpRegistry.Invoke("norm", result, src, dimension, value); }
        /// <summary>
        /// Standards the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Std(ArithArray result, ArithArray src, int dimension, bool normByN) { return (ArithArray)OpRegistry.Invoke("std", result, src, dimension, normByN); }
        /// <summary>
        /// Variables the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Var(ArithArray result, ArithArray src, int dimension, bool normByN) { return (ArithArray)OpRegistry.Invoke("var", result, src, dimension, normByN); }

        /// <summary>
        /// Sums all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray SumAll(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("sumall", result, src); }
        /// <summary>
        /// Products all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray ProdAll(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("prodall", result, src); }
        /// <summary>
        /// Minimums all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray MinAll(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("minall", result, src); }
        /// <summary>
        /// Maximums all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray MaxAll(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("maxall", result, src); }

        /// <summary>
        /// Means all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray MeanAll(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("meanall", result, src); }
        /// <summary>
        /// Norms all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray NormAll(ArithArray result, ArithArray src, float value) { return (ArithArray)OpRegistry.Invoke("normall", result, src, value); }
        /// <summary>
        /// Standards all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray StdAll(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("stdall", result, src); }
        /// <summary>
        /// Variables all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray VarAll(ArithArray result, ArithArray src) { return (ArithArray)OpRegistry.Invoke("varall", result, src); }


        /// <summary>
        /// Sums all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float SumAll(ArithArray src) { using (var resultTensor = SumAll(null, src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Products all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float ProdAll(ArithArray src) { using (var resultTensor = ProdAll(null, src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Minimums all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float MinAll(ArithArray src) { using (var resultTensor = MinAll(null, src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Maximums all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float MaxAll(ArithArray src) { using (var resultTensor = MaxAll(null, src)) { return resultTensor.GetElementAsFloat(0); } }

        /// <summary>
        /// Means all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float MeanAll(ArithArray src) { using (var resultTensor = MeanAll(null, src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Variables all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float VarAll(ArithArray src) { using (var resultTensor = VarAll(null, src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Standards all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>System.Single.</returns>
        public static float StdAll(ArithArray src) { using (var resultTensor = StdAll(null, src)) { return resultTensor.GetElementAsFloat(0); } }
        /// <summary>
        /// Norms all.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        public static float NormAll(ArithArray src, float value) { using (var resultTensor = NormAll(null, src, value)) { return resultTensor.GetElementAsFloat(0); } }


        /// <summary>
        /// Indexes the select.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray IndexSelect(ArithArray result, ArithArray src, int dim, ArithArray indices) { return (ArithArray)OpRegistry.Invoke("index_select", result, src, dim, indices); }
        /// <summary>
        /// Gathers the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Gather(ArithArray result, ArithArray src, int dim, ArithArray indices) { return (ArithArray)OpRegistry.Invoke("gather", result, src, dim, indices); }
        /// <summary>
        /// Scatters the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray Scatter(ArithArray result, ArithArray src, int dim, ArithArray indices)
        {
            if (result == null)
                result = src;
            return (ArithArray)OpRegistry.Invoke("scatter", result, src, dim, indices);
        }
        /// <summary>
        /// Scatters the fill.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="value">The value.</param>
        /// <param name="dim">The dim.</param>
        /// <param name="indices">The indices.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray ScatterFill(ArithArray result, float value, int dim, ArithArray indices) { return (ArithArray)OpRegistry.Invoke("scatter_fill", result, value, dim, indices); }


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
