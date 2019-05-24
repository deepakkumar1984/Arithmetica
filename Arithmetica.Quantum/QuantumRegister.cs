using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica.Quantum
{
    /// <summary>
    /// Quantum Register for holding Quantum bit values
    /// </summary>
    public class QuantumRegister
    {
        /// <summary>
        /// Vector representation of a quantum register
        /// </summary>
        /// <value>
        /// The register.
        /// </value>
        public ComplexVector BitRegister { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumRegister"/> class.
        /// </summary>
        /// <param name="complex">The complex.</param>
        public QuantumRegister(ComplexVector complex)
        {
            BitRegister = complex;
            BitRegister.Normalize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumRegister"/> class.
        /// </summary>
        /// <param name="complexArray">The complex array.</param>
        public QuantumRegister(params Complex[] complexArray)
        {
            BuildRegister(complexArray);
            BitRegister.Normalize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumRegister"/> class.
        /// </summary>
        /// <param name="registers">The registers.</param>
        public QuantumRegister(params QuantumRegister[] registers)
        {
            List<Complex> complexArray = new List<Complex>();
            foreach (var item in registers)
            {
                complexArray.AddRange(item.BitRegister.Variable);
            }

            BuildRegister(complexArray.ToArray());
            BitRegister.Normalize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumRegister"/> class.
        /// </summary>
        /// <param name="num">The number of qubits in the register.</param>
        public QuantumRegister(int num = 1)
        {
            var registers = new QuantumRegister[num];
            for (int i = 0; i < registers.Length; i++)
            {
                registers[i] = Qubit.Zero;
            }

            List<Complex> complexArray = new List<Complex>();
            foreach (var item in registers)
            {
                complexArray.AddRange(item.BitRegister.Variable);
            }

            BuildRegister(complexArray.ToArray());
            BitRegister.Normalize();
        }

       
        /// <summary>
        /// Einstein–Podolsky–Rosen pair
        /// </summary>
        /// <value>
        /// The epr pair.
        /// </value>
        public static QuantumRegister EPRPair
        {
            get
            {
                ComplexVector complex = new ComplexVector(4);
                complex[0] = Complex.One;
                complex[1] = Complex.Zero;
                complex[2] = Complex.Zero;
                complex[3] = Complex.One;

                complex = complex / (float)Math.Sqrt(2);
                return new QuantumRegister(complex);
            }
        }

        /// <summary>
        /// Generalized W state
        /// </summary>
        /// <value>
        /// The state of the GHZ.
        /// </value>
        public static QuantumRegister GHZState
        {
            get
            {
                return QuantumRegister.GHZStateOfLength(3);
            }
        }

        /// <summary>
        /// W State
        /// </summary>
        /// <value>
        /// The state of the w.
        /// </value>
        public static QuantumRegister WState
        {
            get
            {
                return QuantumRegister.WStateOfLength(3);
            }
        }

        /// <summary>
        /// Creates a WState of specified length
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static QuantumRegister WStateOfLength(int length)
        {
            ComplexVector vector = ComplexVector.Zero(1 << length);
            
            for (int i = 0; i < length; i++)
            {
                vector[1 << i] = Complex.One;
            }

            return new QuantumRegister(vector / (float)Math.Sqrt(3));
        }

        /// <summary>
        /// Created Generalized W Statue of specified length
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static QuantumRegister GHZStateOfLength(int length)
        {
            ComplexVector vector = ComplexVector.Zero(1 << length);

            vector[0] = Complex.One;
            vector[(1 << length) - 1] = Complex.One;

            return new QuantumRegister(vector / (float)Math.Sqrt(2));
        }

        /// <summary>
        /// Collapses a quantum register into a pure state
        /// </summary>
        internal void Collapse()
        {
            Random random = new Random();
            ComplexVector collapsed = new ComplexVector(BitRegister.Size);
            double probabilityThreshold = random.NextDouble();
            if(probabilityThreshold <= 0.5)
            {
                collapsed[0] = new Complex(1, 0);
                collapsed[1] = new Complex(0, 0);
            }
            else
            {
                collapsed[0] = new Complex(0, 0);
                collapsed[1] = new Complex(1, 0);
            }

            BitRegister = collapsed;
        }

        /// <summary>
        /// eturns the value contained in a quantum register, with optional portion start and length
        /// </summary>
        /// <param name="portionStart">The portion start.</param>
        /// <param name="portionLength">Length of the portion.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">The supplied portion overflows the given quantum register.</exception>
        /// <exception cref="SystemException">A value can only be extracted from a pure state quantum register.</exception>
        public int GetValue(int portionStart = 0, int portionLength = 0)
        {
            int registerLength = QCUtil.Log2((int)this.BitRegister.Size - 1);
            if (portionLength == 0)
            {
                portionLength = registerLength - portionStart;
            }

            int trailingBitCount = registerLength - portionStart - portionLength;
            if (trailingBitCount < 0)
            {
                throw new ArgumentException("The supplied portion overflows the given quantum register.");
            }

            int index = -1;
            for (int i = 0; i < this.BitRegister.Size; i++)
            {
                if (this.BitRegister[i].Real == 1)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new SystemException("A value can only be extracted from a pure state quantum register.");
            }

            // If trailing bits need to be removed
            if (trailingBitCount > 0)
            {
                index >>= trailingBitCount;
            }

            // If leading bits need to be removed
            if (portionStart > 0)
            {
                index &= (1 << portionLength) - 1;
            }

            return index;
        }

        /// <summary>
        /// Builds the register.
        /// </summary>
        /// <param name="complexArray">The complex array.</param>
        private void BuildRegister(Complex[] complexArray)
        {
            BitRegister = new ComplexVector(complexArray.Length);
            BitRegister.Variable = complexArray;
        }

        /// <summary>
        /// Gets the qubits from the register.
        /// </summary>
        /// <returns>
        /// The qubit.
        /// </returns>
        public Qubit[] GetQubits()
        {
            int num = BitRegister.Size / 2;
            Qubit[] qubits = new Qubit[num];

            for (int i = 0; i < num; i++)
            {
                qubits[i] = new Qubit(BitRegister[i * 2], BitRegister[i * 2 + 1]);
            }

            return qubits;
        }

        public override string ToString()
        {
            string representation = "";

            var qubits = GetQubits();
            int i = 0;
            foreach (var item in qubits)
            {
                if (item == null)
                    continue;

                representation += string.Format("Q{0}: {1}", i, QubitString(item));
                representation += "   ";
                i++;
            }

            return representation;
        }

        private string QubitString(Qubit qubit)
        {
            string representation = "";

            for (int i = 0; i < qubit.BitRegister.Size; i++)
            {
                Complex amplitude = qubit.BitRegister[i];

                if (amplitude.Real != 0)
                {
                    string complexString = "";

                    if (amplitude.Real < 0 || amplitude.Real == 0 && amplitude.Imaginary < 0)
                    {
                        complexString += " - ";
                        amplitude = -amplitude;
                    }
                    else if (representation.Length > 0)
                    {
                        complexString += " + ";
                    }

                    if (amplitude.Real != 1)
                    {
                        if (amplitude.Real != 0 && amplitude.Imaginary != 0)
                        {
                            complexString += "(";
                        }

                        if (amplitude.Real != 0)
                        {
                            complexString += amplitude.Real;
                        }

                        if (amplitude.Real != 0 && amplitude.Imaginary > 0)
                        {
                            complexString += " + ";
                        }

                        if (amplitude.Imaginary != 0)
                        {
                            complexString += amplitude.Imaginary + " i";
                        }

                        if (amplitude.Real != 0 && amplitude.Imaginary != 0)
                        {
                            complexString += ")";
                        }

                        complexString += " ";
                    }

                    representation += complexString + "|" + Convert.ToString(i, 2) + ">";
                }
            }

            return representation;
        }
    }
}
