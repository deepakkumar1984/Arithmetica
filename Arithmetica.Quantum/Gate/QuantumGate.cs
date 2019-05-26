using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica.Quantum.Gate
{
    public abstract class QuantumGate
    {
        public string Name { get; set; }

        public ComplexMatrix Matrix { get; set; }

        public QuantumGate(string name)
        {
            Name = name;
        }

        public virtual void Apply(params Qubit[] qubits)
        {
            Parallel.For(0, qubits.Length, (i) => {
                qubits[i].BitRegister = ComplexMatrix.Multiply(Matrix, qubits[i].BitRegister);
            });
        }

        internal ComplexMatrix ControlledGateMatrix(ComplexMatrix gateMatrix)
        {
            if (gateMatrix.ColumnCount != 2 || gateMatrix.RowCount != 2)
            {
                throw new ArgumentException("A controlled gate can only be created from a unary gate.");
            }

            return new Complex[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, gateMatrix[0, 0], gateMatrix[0, 1] },
                { 0, 0, gateMatrix[1, 0], gateMatrix[1, 1] },
            };
        }
    }
}
