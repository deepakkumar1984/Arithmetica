using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    public abstract class QuantumGate
    {
        public string Name { get; set; }

        public ComplexMatrix Matrix { get; set; }

        public QuantumGate(string name)
        {
            Name = name;
        }

        public virtual void Apply(QuantumRegister register)
        {
            register.Variable = ComplexMatrix.Multiply(Matrix, register.Variable);
        }
    }
}
