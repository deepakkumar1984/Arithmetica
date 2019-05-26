using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arithmetica.Quantum.Gate
{
    internal partial class QGate
    {
        public ComplexMatrix Matrix { get; private set; }

        public QGate(params QGate[] quantumGates) : this((IEnumerable<QGate>)quantumGates) { }

        public QGate(IEnumerable<QGate> quantumGates)
        {
            this.Matrix = quantumGates.Aggregate(new ComplexMatrix(new Complex[] { Complex.One }), (matrix, quantumGate) => ComplexMatrix.CrossProduct(matrix, quantumGate.Matrix));
        }

        public QGate(Complex[,] coefficients) : this(new ComplexMatrix(coefficients)) { }


        public QGate(ComplexMatrix matrix)
        {
            if ((matrix.ColumnCount & (matrix.ColumnCount - 1)) != 0 || matrix.ColumnCount != matrix.RowCount)
            {
                throw new ArgumentException("A quantum gate can only be initialized from a square matrix whose order is a power of 2.");
            }

            this.Matrix = matrix;
        }

        public static QGate IdentityGate
        {
            get
            {
                return QGate.IdentityGateOfLength(1);
            }
        }

        /*
		 * Stacked identity gates
		 */
        public static QGate IdentityGateOfLength(int registerLength)
        {
            return new QGate(new ComplexMatrix(1 << registerLength));
        }

        public static QGate HadamardGate
        {
            get
            {
                return new QGate(new ComplexMatrix(new Complex[,] {
                    { 1, 1 },
                    { 1, -1 },
                }) / Math.Sqrt(2));
            }
        }

        /*
		 * Generalized Hadamard gate
		 */
        public static QGate HadamardGateOfLength(int registerLength)
        {
            if (registerLength == 1)
            {
                return QGate.HadamardGate;
            }
            else
            {
                return new QGate(QGate.HadamardGate, QGate.HadamardGateOfLength(registerLength - 1));
            }
        }

        /// <summary>
        /// Pauli X Gate also called Not gate
        /// </summary>
        /// <value>
        /// The not gate.
        /// </value>
        public static QGate NotGate
        {
            get
            {
                return new QGate(new Complex[,] {
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
        public static QGate PauliYGate
        {
            get
            {
                return new QGate(new Complex[,] {
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
        public static QGate PauliZGate
        {
            get
            {
                return new QGate(new Complex[,] {
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
        public static QGate SquareRootNotGate
        {
            get
            {
                return new QGate(new ComplexMatrix(new Complex[,] {
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
        public static QGate PhaseShiftGate(double phase)
        {
            return new QGate(new Complex[,] {
                { 1, 0 },
                { 0, QCUtil.ComplexExp(Complex.ImaginaryOne * phase)},
            });
        }

        /*
		 * Swap gate
		 */
        public static QGate SwapGate
        {
            get
            {
                return new QGate(new Complex[,] {
                    { 1, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 1 },
                });
            }
        }

        public static QGate SquareRootSwapGate
        {
            get
            {
                return new QGate(new Complex[,] {
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
        public static QGate ControlledNotGate
        {
            get
            {
                return QGate.ControlledGate(QGate.NotGate);
            }
        }

        public static QGate ControlledGate(QGate gate)
        {
            if (gate.Matrix.ColumnCount != 2 || gate.Matrix.RowCount != 2)
            {
                throw new ArgumentException("A controlled gate can only be created from a unary gate.");
            }

            return new QGate(new Complex[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, gate.Matrix[0, 0], gate.Matrix[0, 1] },
                { 0, 0, gate.Matrix[1, 0], gate.Matrix[1, 1] },
            });
        }

        /*
		 * Toffoli gate
		 */
        public static QGate ToffoliGate
        {
            get
            {
                return new QGate(new Complex[,] {
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

        public static QGate FredkinGate
        {
            get
            {
                return new QGate(new Complex[,] {
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
        public static QGate QuantumFourierTransform(int registerLength)
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

            return new QGate(matrix);
        }

        /*
		 * Operator to apply a quantum gate to a quantum register
		 */
        public static QuantumRegister operator *(QGate quantumGate, QuantumRegister quantumRegister)
        {
            return new QuantumRegister(QuantumRegister.GetQubits(ComplexMatrix.Multiply(quantumGate.Matrix, quantumRegister.BitRegister)));
        }

        public static Qubit operator *(QGate quantumGate, Qubit qubit)
        {
            var vector = ComplexMatrix.Multiply(quantumGate.Matrix, qubit.BitRegister);
            return new Qubit(vector[0], vector[1]);
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
            QGate quantumGate = obj as QGate;

            if (quantumGate == null || this.Matrix.ColumnCount != quantumGate.Matrix.ColumnCount || this.Matrix.RowCount != quantumGate.Matrix.RowCount)
            {
                return false;
            }

            return this.Matrix.Equals(quantumGate.Matrix);
        }
      
    }
}
