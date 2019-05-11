// ***********************************************************************
// Assembly         : Arithmetica
// Author           : Community
// Created          : 12-09-2018
//
// Last Modified By : Deepak Battini
// Last Modified On : 11-25-2018
// ***********************************************************************
// <copyright file="TensorResultBuilder.cs" company="Arithmetica">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Arithmetica.Core
{
    using System;

    /// <summary>
    /// Class TensorResultBuilder.
    /// </summary>
    internal static class ArrayResultBuilder
    {
        // If a maybeResult is null, a new array will be constructed using the device id and element type of newTemplate
        /// <summary>
        /// Gets the write target.
        /// </summary>
        /// <param name="maybeResult">The maybe result.</param>
        /// <param name="newTemplate">The new template.</param>
        /// <param name="requireContiguous">if set to <c>true</c> [require contiguous].</param>
        /// <param name="requiredSizes">The required sizes.</param>
        /// <returns>Tensor.</returns>
        public static ArithArray GetWriteTarget(ArithArray maybeResult, ArithArray newTemplate, bool requireContiguous, params long[] requiredSizes)
        {
            return GetWriteTarget(maybeResult, newTemplate.Allocator, newTemplate.ElementType, requireContiguous, requiredSizes);
        }

        /// <summary>
        /// Gets the write target.
        /// </summary>
        /// <param name="maybeResult">The maybe result.</param>
        /// <param name="allocatorForNew">The allocator for new.</param>
        /// <param name="elementTypeForNew">The element type for new.</param>
        /// <param name="requireContiguous">if set to <c>true</c> [require contiguous].</param>
        /// <param name="requiredSizes">The required sizes.</param>
        /// <returns>Tensor.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static ArithArray GetWriteTarget(ArithArray maybeResult, IAllocator allocatorForNew, DType elementTypeForNew, bool requireContiguous, params long[] requiredSizes)
        {
            if (maybeResult != null)
            {
                if (!MatchesRequirements(maybeResult, requireContiguous, requiredSizes))
                {
                    var message = string.Format("output array does not match requirements. Tensor must have sizes {0}{1}",
                        string.Join(", ", requiredSizes),
                        requireContiguous ? "; and must be contiguous" : "");

                    throw new InvalidOperationException(message);
                }
                return maybeResult;
            }
            else
            {
                return new ArithArray(requiredSizes, elementTypeForNew);
            }
        }

        /// <summary>
        /// Matcheses the requirements.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="requireContiguous">if set to <c>true</c> [require contiguous].</param>
        /// <param name="requiredSizes">The required sizes.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool MatchesRequirements(ArithArray array, bool requireContiguous, params long[] requiredSizes)
        {
            if (requireContiguous && !array.IsContiguous())
            {
                return false;
            }

            return ArrayEqual(array.Shape, requiredSizes);
        }

        /// <summary>
        /// Arrays the equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ArrayEqual<T>(T[] a, T[] b)
        {
            if (a.Length != b.Length)
                return false;

            for(int i = 0; i < a.Length; ++i)
            {
                if (!a[i].Equals(b[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Arrays the equal except.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="ignoreIndex">Index of the ignore.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ArrayEqualExcept<T>(T[] a, T[] b, int ignoreIndex)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; ++i)
            {
                if (i == ignoreIndex)
                    continue;

                if (!a[i].Equals(b[i]))
                    return false;
            }

            return true;
        }
    }
}
