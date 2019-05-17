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
    public class QCRegister
    {
        /// <summary>
        /// Vector representation of a quantum register
        /// </summary>
        /// <value>
        /// The register.
        /// </value>
        public Complex Register { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QCRegister"/> class.
        /// </summary>
        /// <param name="complex">The complex.</param>
        public QCRegister(Complex complex)
        {
            Register = complex;
            Register.Normalize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QCRegister"/> class.
        /// </summary>
        /// <param name="complexArray">The complex array.</param>
        public QCRegister(params Complex[] complexArray)
        {
            BuildRegister(complexArray);
            Register.Normalize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QCRegister"/> class.
        /// </summary>
        /// <param name="registers">The registers.</param>
        public QCRegister(params QCRegister[] registers)
        {
            List<Complex> complexArray = new List<Complex>();
            foreach (var item in registers)
            {
                complexArray.Add(item.Register);
            }

            BuildRegister(complexArray.ToArray());
            Register.Normalize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QCRegister"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="bitCount">The bit count.</param>
        public QCRegister(int value, int bitCount = 1)
        {
            Register = new Complex(bitCount);
            Register.Fill(value);
        }

        /// <summary>
        /// Einstein–Podolsky–Rosen pair
        /// </summary>
        /// <value>
        /// The epr pair.
        /// </value>
        public static QCRegister EPRPair
        {
            get
            {
                Complex complex = new Complex(4);
                complex[0] = (1, 0);
                complex[1] = (0, 0);
                complex[2] = (0, 0);
                complex[3] = (1, 0);

                complex = complex / (float)Math.Sqrt(2);
                return new QCRegister(complex);
            }
        }

        /// <summary>
        /// Generalized W state
        /// </summary>
        /// <value>
        /// The state of the GHZ.
        /// </value>
        public static QCRegister GHZState
        {
            get
            {
                return QCRegister.GHZStateOfLength(3);
            }
        }

        /// <summary>
        /// W State
        /// </summary>
        /// <value>
        /// The state of the w.
        /// </value>
        public static QCRegister WState
        {
            get
            {
                return QCRegister.WStateOfLength(3);
            }
        }

        /// <summary>
        /// Creates a WState of specified length
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static QCRegister WStateOfLength(int length)
        {
            Complex vector = new Complex(1 << length);

            for (int i = 0; i < length; i++)
            {
                vector.Set(1 << i, Complex.One);
            }

            return new QCRegister(vector / (float)Math.Sqrt(3));
        }

        /// <summary>
        /// Created Generalized W Statue of specified length
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static QCRegister GHZStateOfLength(int length)
        {
            Complex vector = new Complex(1 << length);

            vector.Set(0, Complex.One);
            vector.Set((1 << length) - 1, Complex.One);

            return new QCRegister(vector / (float)Math.Sqrt(2));
        }

        /// <summary>
        /// Collapses a quantum register into a pure state
        /// </summary>
        /// <param name="random">The random.</param>
        public void Collapse(Random random)
        {
            Complex collapsed = new Complex(Register.Size);

            double probabilitySum = 0d;
            double probabilityThreshold = random.NextDouble();

            for (int i = 0; i < this.Register.Size; i++)
            {
                probabilitySum += this.Register.Get(i).MagnitudeSquared;

                if (probabilitySum > probabilityThreshold)
                {
                    collapsed[i] = (1, 0);
                    break;
                }
            }

            Register = collapsed;
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
            int registerLength = QCUtil.Log2((int)this.Register.Size - 1);
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
            for (int i = 0; i < this.Register.Size; i++)
            {
                if (this.Register.Get(i).Real == 1)
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
            long size = 0;
            foreach (var item in complexArray)
            {
                size += item.Size;
            }

            Register = new Complex(size);

            int counter = 0;
            foreach (var item in complexArray)
            {
                for (int i = 0; i < item.Size; i++)
                {
                    Register[counter] = item[i];
                    counter++;
                }
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

            for (int i = 0; i < this.Register.Size; i++)
            {
                Complex amplitude = this.Register.Get(i);

                if (amplitude.Real != 0)
                {
                    string complexString = "";

                    if (amplitude.Real < 0 || amplitude.Real == 0 && amplitude.Imag < 0)
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
                        if (amplitude.Real != 0 && amplitude.Imag != 0)
                        {
                            complexString += "(";
                        }

                        if (amplitude.Real != 0)
                        {
                            complexString += amplitude.Real;
                        }

                        if (amplitude.Real != 0 && amplitude.Imag > 0)
                        {
                            complexString += " + ";
                        }

                        if (amplitude.Imag != 0)
                        {
                            complexString += amplitude.Imag + " i";
                        }

                        if (amplitude.Real != 0 && amplitude.Imag != 0)
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
