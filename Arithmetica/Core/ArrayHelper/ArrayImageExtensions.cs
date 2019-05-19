// ***********************************************************************
// Assembly         : Arithmetica
// Author           : Community
// Created          : 12-09-2018
//
// Last Modified By : Deepak Battini
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="TensorImageExtensions.cs" company="Arithmetica">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Arithmetica.Extensions
{
    /// <summary>
    /// Class TensorImageExtensions.
    /// </summary>
    public static class ArrayImageExtensions
    {
        /// <summary>
        /// Converts a ArithArray to a Bitmap. Elements of the array are assumed to be normalized in the range [0, 1]
        /// The array must have one of the following structures:
        /// * 2D array - output is a 24bit BGR bitmap in greyscale
        /// * 3D array where first dimension has length 1 - output is 24bit BGR bitmap in greyscale
        /// * 3D array where first dimension has length 3 - output is 24bit BGR bitmap
        /// * 3D array where first dimension has length 4 - output is 32bit BGRA bitmap
        /// 2D tensors must be in HW (height x width) order;
        /// 3D tensors must be in CHW (channel x height x width) order.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Bitmap.</returns>
        /// <exception cref="InvalidOperationException">
        /// array must have 2 or 3 dimensions
        /// or
        /// 3D array's first dimension (color channels) must be of length 1, 3 or 4
        /// </exception>
        public static Bitmap ToBitmap(this ArithArray array)
        {
            if (array.DimensionCount != 2 && array.DimensionCount != 3)
                throw new InvalidOperationException("array must have 2 or 3 dimensions");

            if (array.DimensionCount == 3 &&
                (array.Shape[0] != 1 && array.Shape[0] != 3 && array.Shape[0] != 4))
                throw new InvalidOperationException("3D array's first dimension (color channels) must be of length 1, 3 or 4");

            ArithArray src;
            if (array.DimensionCount == 2)
                src = array.RepeatTensor(3, 1, 1);
            else if (array.DimensionCount == 3 && array.Shape[0] == 1)
                src = array.RepeatTensor(3, 1, 1);
            else
                src = array.CopyRef();

            var bytesPerPixel = src.Shape[0];

            try
            {
                using (var cpuFloatTensor = new ArithArray(src.Shape, DType.Float32))
                using (var permutedFloatTensor = cpuFloatTensor.Transpose(1, 2, 0))
                {
                    var resultFormat = bytesPerPixel == 3 ? PixelFormat.Format24bppRgb : PixelFormat.Format32bppArgb;
                    var result = new Bitmap((int)src.Shape[2], (int)src.Shape[1], resultFormat);



                    var lockData = result.LockBits(
                        new Rectangle(0, 0, result.Width, result.Height),
                        ImageLockMode.WriteOnly,
                        result.PixelFormat);

                    var sizes = new long[] { result.Height, result.Width, bytesPerPixel };
                    var strides = new long[] { lockData.Stride, bytesPerPixel, 1 };
                    var resultTensor = new ArithArray(sizes, strides, DType.UInt8);

                    // Re-order array and convert to bytes
                    ArrayOps.Copy(resultTensor, permutedFloatTensor);

                    var byteLength = lockData.Stride * lockData.Height;
                    resultTensor.Storage.CopyFromStorage(lockData.Scan0, resultTensor.StorageOffset, byteLength);

                    result.UnlockBits(lockData);
                    return result;
                }
            }
            finally
            {
                src.Dispose();
            }
        }
    }
}
