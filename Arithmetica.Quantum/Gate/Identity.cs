using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class Identity : QuantumGate
    {
        public Identity(int registerLength = 1) : base("I")
        {
            Matrix = new ComplexMatrix(1 << registerLength);
        }
    }
}
