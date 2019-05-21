using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arithmetica.Quantum
{
    public class QCGate
    {
        public ComplexMatrix Matrix { get; private set; }

        public QCGate(params QCGate[] quantumGates) : this((IEnumerable<QCGate>)quantumGates) { }

        public QCGate(IEnumerable<QCGate> quantumGates)
        {
            this.Matrix = quantumGates.Aggregate(new ComplexMatrix(new Complex[] { Complex.One }), (matrix, quantumGate) => ComplexMatrix.CrossProduct(matrix, quantumGate.Matrix));
        }

        public QCGate(Complex[,] coefficients) : this(new ComplexMatrix(coefficients)) { }


        public QCGate(ComplexMatrix matrix)
        {
            if ((matrix.ColumnCount & (matrix.ColumnCount - 1)) != 0 || matrix.ColumnCount != matrix.RowCount)
            {
                throw new ArgumentException("A quantum gate can only be initialized from a square matrix whose order is a power of 2.");
            }

            this.Matrix = matrix;
        }

        public static QCGate IdentityGate
        {
            get
            {
                return QCGate.IdentityGateOfLength(1);
            }
        }

        /*
		 * Stacked identity gates
		 */
        public static QCGate IdentityGateOfLength(int registerLength)
        {
            return new QCGate(new ComplexMatrix(1 << registerLength));
        }

        public static QCGate HadamardGate
        {
            get
            {
                return new QCGate(new ComplexMatrix(new Complex[,] {
                    { 1, 1 },
                    { 1, -1 },
                }) / Math.Sqrt(2));
            }
        }

        /*
		 * Generalized Hadamard gate
		 */
        public static QCGate HadamardGateOfLength(int registerLength)
        {
            if (registerLength == 1)
            {
                return QCGate.HadamardGate;
            }
            else
            {
                return new QCGate(QCGate.HadamardGate, QCGate.HadamardGateOfLength(registerLength - 1));
            }
        }

        public static QCGate NotGate
        {
            get
            {
                return new QCGate(new Complex[,] {
                    { 0, 1 },
                    { 1, 0 },
                });
            }
        }

        /*
		 * Pauli-Y gate
		 */
        public static QCGate PauliYGate
        {
            get
            {
                return new QCGate(new Complex[,] {
                    { 0, -Complex.ImaginaryOne },
                    { Complex.ImaginaryOne, 0 },
                });
            }
        }

        public static QCGate PauliZGate
        {
            get
            {
                return new QCGate(new Complex[,] {
                    { 1, 0 },
                    { 0, -1 },
                });
            }
        }

        /*
		 * Square root of NOT gate
		 */
        public static QCGate SquareRootNotGate
        {
            get
            {
                return new QCGate(new ComplexMatrix(new Complex[,] {
                    { 1 + Complex.ImaginaryOne, 1 - Complex.ImaginaryOne },
                    { 1 - Complex.ImaginaryOne, 1 + Complex.ImaginaryOne },
                }) / 2);
            }
        }

        public static QCGate PhaseShiftGate(double phase)
        {
            return new QCGate(new Complex[,] {
                { 1, 0 },
                { 0, Complex.ImaginaryOne * phase},
            });
        }

        /*
		 * Swap gate
		 */
        public static QCGate SwapGate
        {
            get
            {
                return new QCGate(new Complex[,] {
                    { 1, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 1 },
                });
            }
        }

        public static QCGate SquareRootSwapGate
        {
            get
            {
                return new QCGate(new Complex[,] {
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
        public static QCGate ControlledNotGate
        {
            get
            {
                return QCGate.ControlledGate(QCGate.NotGate);
            }
        }

        public static QCGate ControlledGate(QCGate gate)
        {
            if (gate.Matrix.ColumnCount != 2 || gate.Matrix.RowCount != 2)
            {
                throw new ArgumentException("A controlled gate can only be created from a unary gate.");
            }

            return new QCGate(new Complex[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, gate.Matrix[0, 0], gate.Matrix[0, 1] },
                { 0, 0, gate.Matrix[1, 0], gate.Matrix[1, 1] },
            });
        }

        /*
		 * Toffoli gate
		 */
        public static QCGate ToffoliGate
        {
            get
            {
                return new QCGate(new Complex[,] {
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

        public static QCGate FredkinGate
        {
            get
            {
                return new QCGate(new Complex[,] {
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
        public static QCGate QuantumFourierTransform(int registerLength)
        {
            int order = 1 << registerLength;

            ComplexMatrix matrix = new ComplexMatrix(order, order);

            // Only n distinct coefficients are found in the quantum Fourier transform matrix
            Complex[] coefficients = new Complex[order];
            for (int i = 0; i < order; i++)
            {
                coefficients[i] = (Complex.ImaginaryOne * 2 * Math.PI * i / order) / Math.Sqrt(order);
            }

            // Populate matrix
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    matrix[i, j] = coefficients[i * j % order];
                }
            }

            return new QCGate(matrix);
        }

        /*
		 * Operator to apply a quantum gate to a quantum register
		 */
        public static QCRegister operator *(QCGate quantumGate, QCRegister quantumRegister)
        {
            return new QCRegister((quantumGate.Matrix * quantumRegister.Register).To1DimArray());
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
            QCGate quantumGate = obj as QCGate;

            if (quantumGate == null || this.Matrix.ColumnCount != quantumGate.Matrix.ColumnCount || this.Matrix.RowCount != quantumGate.Matrix.RowCount)
            {
                return false;
            }

            return this.Matrix.Equals(quantumGate.Matrix);
        }
      
    }
}
