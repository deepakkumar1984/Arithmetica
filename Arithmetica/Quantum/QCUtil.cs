using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    internal class QCUtil
    {
        public static int NextStrictlyLargerPowerOfTwo(int value)
        {
            value |= (value >> 1);
            value |= (value >> 2);
            value |= (value >> 4);
            value |= (value >> 8);
            value |= (value >> 16);

            return value + 1;
        }
    }
}
