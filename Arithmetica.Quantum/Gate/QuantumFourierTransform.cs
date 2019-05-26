using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    public class QuantumFourierTransform : QuantumGate
    {
        public QuantumFourierTransform(int registerLength = 1) : base("QFT")
        {
            int order = 1 << registerLength;

            Matrix = new ComplexMatrix(order, order);

            // Only n distinct coefficients are found in the quantum Fourier transform matrix
            Complex[] coefficients = new Complex[order];
            for (int i = 0; i < order; i++)
            {
                coefficients[i] = QCUtil.ComplexExp(Complex.ImaginaryOne * 2 * Math.PI * i / order) / Math.Sqrt(order);
            }

            // Populate matrix
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    Matrix[i, j] = coefficients[i * j % order];
                }
            }
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
