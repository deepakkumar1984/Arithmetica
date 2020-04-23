using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The quantum Fourier transform (for short: QFT) is a linear transformation on quantum bits, and is the quantum analogue of the inverse discrete Fourier transform. 
    /// The quantum Fourier transform is a part of many quantum algorithms, notably Shor's algorithm for factoring and computing the discrete logarithm, 
    /// the quantum phase estimation algorithm for estimating the eigenvalues of a unitary operator, and algorithms for the hidden subgroup problem.
    /// <para>
    /// Wikipedia: https://en.wikipedia.org/wiki/Quantum_Fourier_transform
    /// </para>
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
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
