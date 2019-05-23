using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Arithmetica.Core
{
    internal class VectorNative
    {
        /// <summary>
        /// The DLL
        /// </summary>
        private const string dll = "lib/arith_ops.dll";
        /// <summary>
        /// The cc
        /// </summary>
        private const CallingConvention cc = CallingConvention.Cdecl;

        [DllImport(dll, CallingConvention = cc)] public static extern int V_Fill(float[] r, float value, int n);

        [DllImport(dll, CallingConvention = cc)] public static extern int V_Add(float[] a, float[] b, float[] r, int n);
        [DllImport(dll, CallingConvention = cc)] public static extern int V_Sub(float[] a, float[] b, float[] r, int n);
        [DllImport(dll, CallingConvention = cc)] public static extern int V_Mul(float[] a, float[] b, float[] r, int n);
        [DllImport(dll, CallingConvention = cc)] public static extern int V_Div(float[] a, float[] b, float[] r, int n);

        [DllImport(dll, CallingConvention = cc)] public static extern int V_Sin(float[] x, float[] r, int n);
        [DllImport(dll, CallingConvention = cc)] public static extern int V_Cos(float[] x, float[] r, int n);
        [DllImport(dll, CallingConvention = cc)] public static extern int V_Tan(float[] x, float[] r, int n);
    }
}
