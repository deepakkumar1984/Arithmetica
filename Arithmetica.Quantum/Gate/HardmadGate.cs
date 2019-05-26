using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class HardmadGate : QuantumGate
    {
        public HardmadGate(int registerLength = 1) : base("H")
        {
            Matrix = HadamardGateOfLength(registerLength);
        }

        private ComplexMatrix HadamardGateOfLength(int registerLength)
        {
            var matrix = new ComplexMatrix(new Complex[,] {
                    { 1, 1 },
                    { 1, -1 },
                }) / Math.Sqrt(2);

            if (registerLength == 1)
            {
                return matrix;
            }
            else
            {
                return HadamardGateOfLength(registerLength - 1);
            }
        }
    }
}
