using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    internal partial class QuantumGate
    {
        public ComplexMatrix Matrix { get; private set; }

        public QuantumGate(params QuantumGate[] quantumGates) : this((IEnumerable<QuantumGate>)quantumGates) { }

        public QuantumGate(IEnumerable<QuantumGate> quantumGates)
        {
            this.Matrix = quantumGates.Aggregate(new ComplexMatrix(new Complex[] { Complex.One }), (matrix, quantumGate) => ComplexMatrix.CrossProduct(matrix, quantumGate.Matrix));
        }

        public QuantumGate(Complex[,] coefficients) : this(new ComplexMatrix(coefficients)) { }


        public QuantumGate(ComplexMatrix matrix)
        {
            if ((matrix.ColumnCount & (matrix.ColumnCount - 1)) != 0 || matrix.ColumnCount != matrix.RowCount)
            {
                throw new ArgumentException("A quantum gate can only be initialized from a square matrix whose order is a power of 2.");
            }

            this.Matrix = matrix;
        }

        public static QuantumGate IdentityGate
        {
            get
            {
                return QuantumGate.IdentityGateOfLength(1);
            }
        }

        /*
		 * Stacked identity gates
		 */
        public static QuantumGate IdentityGateOfLength(int registerLength)
        {
            return new QuantumGate(new ComplexMatrix(1 << registerLength));
        }

        public static QuantumGate HadamardGate
        {
            get
            {
                return new QuantumGate(new ComplexMatrix(new Complex[,] {
                    { 1, 1 },
                    { 1, -1 },
                }) / Math.Sqrt(2));
            }
        }

        /*
		 * Generalized Hadamard gate
		 */
        public static QuantumGate HadamardGateOfLength(int registerLength)
        {
            if (registerLength == 1)
            {
                return QuantumGate.HadamardGate;
            }
            else
            {
                return new QuantumGate(QuantumGate.HadamardGate, QuantumGate.HadamardGateOfLength(registerLength - 1));
            }
        }

        /// <summary>
        /// Pauli X Gate also called Not gate
        /// </summary>
        /// <value>
        /// The not gate.
        /// </value>
        public static QuantumGate NotGate
        {
            get
            {
                return new QuantumGate(new Complex[,] {
                    { 0, 1 },
                    { 1, 0 },
                });
            }
        }

        /// <summary>
        /// Gets the pauli y gate.
        /// </summary>
        /// <value>
        /// The pauli y gate.
        /// </value>
        public static QuantumGate PauliYGate
        {
            get
            {
                return new QuantumGate(new Complex[,] {
                    { 0, -Complex.ImaginaryOne },
                    { Complex.ImaginaryOne, 0 },
                });
            }
        }

        /// <summary>
        /// Gets the pauli z gate.
        /// </summary>
        /// <value>
        /// The pauli z gate.
        /// </value>
        public static QuantumGate PauliZGate
        {
            get
            {
                return new QuantumGate(new Complex[,] {
                    { 1, 0 },
                    { 0, -1 },
                });
            }
        }

        /// <summary>
        /// Gets the square root of not gate.
        /// </summary>
        /// <value>
        /// The square root not gate.
        /// </value>
        public static QuantumGate SquareRootNotGate
        {
            get
            {
                return new QuantumGate(new ComplexMatrix(new Complex[,] {
                    { 1 + Complex.ImaginaryOne, 1 - Complex.ImaginaryOne },
                    { 1 - Complex.ImaginaryOne, 1 + Complex.ImaginaryOne },
                }) / 2);
            }
        }

        /// <summary>
        /// Phases the shift gate.
        /// </summary>
        /// <param name="phase">The phase.</param>
        /// <returns></returns>
        public static QuantumGate PhaseShiftGate(double phase)
        {
            return new QuantumGate(new Complex[,] {
                { 1, 0 },
                { 0, QCUtil.ComplexExp(Complex.ImaginaryOne * phase)},
            });
        }

        /*
		 * Swap gate
		 */
        public static QuantumGate SwapGate
        {
            get
            {
                return new QuantumGate(new Complex[,] {
                    { 1, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 1 },
                });
            }
        }

        public static QuantumGate SquareRootSwapGate
        {
            get
            {
                return new QuantumGate(new Complex[,] {
                    { 1, 0, 0, 0 },
                    { 0, (1 + Complex.ImaginaryOne) / 2, (1 - Complex.ImaginaryOne) / 2, 0 },
                    { 0, (1 - Complex.ImaginaryOne) / 2, (1 + Complex.ImaginaryOne) / 2, 0 },
                    { 0, 0, 0, 1 },
                });
            }
        }

        /*
		 * Controlled NOT gate
		 */
        public static QuantumGate ControlledNotGate
        {
            get
            {
                return QuantumGate.ControlledGate(QuantumGate.NotGate);
            }
        }

        public static QuantumGate ControlledGate(QuantumGate gate)
        {
            if (gate.Matrix.ColumnCount != 2 || gate.Matrix.RowCount != 2)
            {
                throw new ArgumentException("A controlled gate can only be created from a unary gate.");
            }

            return new QuantumGate(new Complex[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, gate.Matrix[0, 0], gate.Matrix[0, 1] },
                { 0, 0, gate.Matrix[1, 0], gate.Matrix[1, 1] },
            });
        }

        /*
		 * Toffoli gate
		 */
        public static QuantumGate ToffoliGate
        {
            get
            {
                return new QuantumGate(new Complex[,] {
                    { 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 0, 0, 0, 0, 0, 0, 1, 0 },
                });
            }
        }

        public static QuantumGate FredkinGate
        {
            get
            {
                return new QuantumGate(new Complex[,] {
                    { 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1 },
                });
            }
        }

        /*
		 * Quantum Fourier transform
		 */
        public static QuantumGate QuantumFourierTransform(int registerLength)
        {
            int order = 1 << registerLength;

            ComplexMatrix matrix = new ComplexMatrix(order, order);

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
                    matrix[i, j] = coefficients[i * j % order];
                }
            }

            return new QuantumGate(matrix);
        }

        /*
		 * Operator to apply a quantum gate to a quantum register
		 */
        public static QuantumRegister operator *(QuantumGate quantumGate, QuantumRegister quantumRegister)
        {
            return new QuantumRegister(ComplexMatrix.Multiply(quantumGate.Matrix, quantumRegister.Register));
        }

        /*
		 * String representation of a quantum gate
		 */
        public override string ToString()
        {
            return this.Matrix.ToString();
        }

        /*
		 * Determines whether the specified quantum gate is equal to the current quantum gate
		 */
        public override bool Equals(object obj)
        {
            QuantumGate quantumGate = obj as QuantumGate;

            if (quantumGate == null || this.Matrix.ColumnCount != quantumGate.Matrix.ColumnCount || this.Matrix.RowCount != quantumGate.Matrix.RowCount)
            {
                return false;
            }

            return this.Matrix.Equals(quantumGate.Matrix);
        }
      
    }
}
