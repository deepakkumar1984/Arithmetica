using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica
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
        public ComplexVector BitRegister
        {
            get
            {
                List<Complex> complexArray = new List<Complex>();
                foreach (var item in Qubits)
                {
                    complexArray.AddRange(item.BitRegister.Variable);
                }

                return new ComplexVector(complexArray.ToArray());
            }
        }

        /// <summary>
        /// Gets the qubits.
        /// </summary>
        /// <value>
        /// The qubits.
        /// </value>
        public Qubit[] Qubits
        {
            get;set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumRegister"/> class.
        /// </summary>
        /// <param name="registers">The registers.</param>
        public QuantumRegister(params Qubit[] qubits)
        {
            Qubits = qubits;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumRegister"/> class.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public QuantumRegister(ComplexVector vector)
        {
            Qubits = GetQubits(vector);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumRegister"/> class.
        /// </summary>
        /// <param name="num">The number of qubits in the register.</param>
        public QuantumRegister(int num = 1)
        {
            Qubits = new Qubit[num];
            for (int i = 0; i < Qubits.Length; i++)
            {
                Qubits[i] = Qubit.Zero;
            }
        }

        /// <summary>
        /// Gets the <see cref="Qubit"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Qubit"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Qubit this[int index]
        {
            get
            {
                return Qubits[index];
            }
            set
            {
                Qubits[index].BitRegister = value.BitRegister;
            }
        }

        /// <summary>
        /// Gets the <see cref="Qubit"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Qubit"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Qubit[] this[int[] indexes]
        {
            get
            {
                Qubit[] result = new Qubit[indexes.Length];
                for (int i = 0; i < indexes.Length; i++)
                    result[i] = this[indexes[i]];

                return result;
            }
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
                return new QuantumRegister(GetQubits(complex));
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

            return new QuantumRegister(GetQubits(vector / (float)Math.Sqrt(3)));
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

            return new QuantumRegister(GetQubits(vector / (float)Math.Sqrt(2)));
        }

        /// <summary>
        /// Returns the value contained in a quantum register, with optional portion start and length
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
        /// Gets the qubits from the register.
        /// </summary>
        /// <returns>
        /// The qubit.
        /// </returns>
        public static Qubit[] GetQubits(ComplexVector vector)
        {
            int num = vector.Size  / 2;
            Qubit[] qubits = new Qubit[num];

            for (int i = 0; i < num; i++)
            {
                qubits[i] = new Qubit(vector[i * 2], vector[i * 2 + 1]);
            }

            return qubits;
        }

        /// <summary>
        /// Gets the all the possible states for the qubits in the register. 
        /// Possibilites are created when the qubit are in superposition state.
        /// </summary>
        /// <value>
        /// The possible states.
        /// </value>
        internal Array PossibleValues
        {
            get
            {
                int totalStates = 1;
                
                for (int i = 0; i < Qubits.Length; i++)
                {
                    totalStates *= Qubits[i].Values.Length;
                }

                int[,] states = new int[totalStates, Qubits.Length];
                int divider = 1;
                
                for (int i = 0; i < Qubits.Length; i++)
                {
                    int k_times;
                    if (Qubits[i].Values.Length > 1)
                    {
                        divider += divider;
                        k_times = totalStates / divider;
                    }
                    else
                        k_times = totalStates;

                    int j_times = totalStates / k_times;

                    int counter = 0;
                    int valueIndex = 0;
                    for (int j = 0; j < j_times; j++)
                    {
                        for (int k = 0; k < k_times; k++)
                        {
                            if(Qubits[i].Values.Length == 1)
                                states[counter, Qubits.Length - 1 - i] = Qubits[i].Values[0];
                            else
                                states[counter, Qubits.Length - 1 - i] = Qubits[i].Values[valueIndex];

                            counter++;
                        }

                        if (valueIndex < 1)
                            valueIndex++;
                        else
                            valueIndex = 0;
                    }
                }

                return states;
            }
        }

        /// <summary>
        /// Gets the all the possible states for the qubits in the register. 
        /// Possibilites are created when the qubit are in superposition state.
        /// </summary>
        /// <value>
        /// The possible values.
        /// </value>
        public List<string> Possiblities
        {
            get
            {
                var p = PossibleValues;
                List<string> result = new List<string>();
                for (int i = 0; i < p.GetLength(0); i++)
                {
                    string representation = "";
                    for (int j = 0; j < p.GetLength(1); j++)
                    {
                        representation += p.GetValue(i, j).ToString();
                    }

                    result.Add(representation);
                }

                return result;
            }
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < Qubits.Length; i++)
            {
                Qubits[i].BitRegister = Qubit.Zero.BitRegister;
            }
        }
      
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string representation = "";
            var p = Possiblities.OrderBy(x=>(x));


            foreach (var item in p)
            {
                if (!string.IsNullOrWhiteSpace(representation))
                    representation += " ~ ";
                representation += string.Format("|{0}>", item);
            }

            return representation;
        }
    }
}
