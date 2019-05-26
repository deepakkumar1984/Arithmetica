using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    internal class QCUtil
    {
        public static Random Random = new Random();

        public static int NextStrictlyLargerPowerOfTwo(int value)
        {
            value |= (value >> 1);
            value |= (value >> 2);
            value |= (value >> 4);
            value |= (value >> 8);
            value |= (value >> 16);

            return value + 1;
        }

        public static int Log2(int value)
        {
            int log2 = 1;

            for (int bitCount = 16; bitCount > 0; bitCount /= 2)
            {
                if (value >= 1 << bitCount)
                {
                    value >>= bitCount;
                    log2 += bitCount;
                }
            }

            return log2;
        }

        public static Complex ComplexExp(Complex value)
        {
            if (value.Equals(Complex.ImaginaryOne * Math.PI / 2))
            {
                return Complex.ImaginaryOne;
            }
            else if (value.Equals(Complex.ImaginaryOne * Math.PI))
            {
                return -Complex.One;
            }
            else if (value.Equals(Complex.ImaginaryOne * 3 * Math.PI / 2))
            {
                return -Complex.ImaginaryOne;
            }
            else
            {
                return Complex.Exp(value);
            }
        }
    }
}
