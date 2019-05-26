using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class SqrtSwap : QuantumGate
    {
        public SqrtSwap() : base("SQRT_SWAP")
        {
            Matrix = new Complex[,] {
                    { 1, 0, 0, 0 },
                    { 0, (1 + Complex.ImaginaryOne) / 2, (1 - Complex.ImaginaryOne) / 2, 0 },
                    { 0, (1 - Complex.ImaginaryOne) / 2, (1 + Complex.ImaginaryOne) / 2, 0 },
                    { 0, 0, 0, 1 } };
        }

        public override void Apply(params Qubit[] qubits)
        {
            var reg = new QuantumRegister(qubits);
            var result = QuantumRegister.GetQubits(ComplexMatrix.Multiply(Matrix, reg.BitRegister));
            for (int i = 0; i < qubits.Length; i++)
                qubits[i].BitRegister = result[i].BitRegister;
        }
    }
}
