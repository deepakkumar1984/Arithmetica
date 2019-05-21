// ***********************************************************************
// Assembly         : Arithmetica
// Author           : Community
// Created          : 12-09-2018
//
// Last Modified By : Deepak Battini
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="CpuNativeHelpers.cs" company="Arithmetica">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Arithmetica.Cpu
{
    /// <summary>
    /// Class CpuNativeHelpers.
    /// </summary>
    internal static class CpuNativeHelpers
    {
        /// <summary>
        /// Gets the buffer start.
        /// </summary>
        /// <param name="Array">The Array.</param>
        /// <returns>IntPtr.</returns>
        public static IntPtr GetBufferStart(ArithArray Array)
        {
            var buffer = ((CpuStorage)Array.Storage).buffer;
            return PtrAdd(buffer, Array.StorageOffset * Array.ElementType.Size());
        }

        /// <summary>
        /// PTRs the add.
        /// </summary>
        /// <param name="ptr">The PTR.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>IntPtr.</returns>
        private static IntPtr PtrAdd(IntPtr ptr, long offset)
        {
            return new IntPtr(ptr.ToInt64() + offset);
        }

    }
}
