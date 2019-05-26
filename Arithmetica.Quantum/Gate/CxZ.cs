using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class CxZ : QuantumGate
    {
        public CxZ() : base("CXZ")
        {
            PauliZ gate = new PauliZ();
            Matrix = ControlledGateMatrix(gate.Matrix);
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
