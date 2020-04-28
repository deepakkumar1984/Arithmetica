using System.Numerics;
using System.Threading.Tasks;

namespace Arithmetica
{
    /// <summary>
    /// Creates a Vector of Complex variables
    /// </summary>
    /// <typeparam name="Complex">The type of the omplex.</typeparam>
    public class ComplexVector
    {
        /// <summary>
        /// Variable to store the complex numbers for this vector
        /// </summary>
        public Complex[] Variable { get; set; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size => Variable.Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector{Complex}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public ComplexVector(int size)
        {
            Variable = new Complex[size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector{Complex}"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public ComplexVector(params Complex[] values)
        {
            Variable = values;
        }

        /// <summary>
        /// Gets or sets the <see cref="Complex"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Complex"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Complex this[int index]
        {
            get
            {
                return Variable[index];
            }
            set
            {
                Variable[index] = value;
            }
        }

        /// <summary>
        /// Gets the conjugate of the vector of complex number.
        /// </summary>
        /// <value>
        /// The conjugate.
        /// </value>
        public ComplexVector Conjugate
        {
            get
            {
                ComplexVector result = new ComplexVector(Size);
                Parallel.For(0, Size, (i) => {
                    result[i] = Complex.Conjugate(this[i]);
                });

                return result;
            }
        }

        /// <summary>
        /// Normalize the vector of complex numbers
        /// </summary>
        public void Normalize()
        {
            Parallel.For(0, Size, (i) => {
                this[i].Normalize();
            });
        }

        #region Constants
        /// <summary>
        ///  A vector of complex number that represents zero.
        /// </summary>
        public static ComplexVector Zero(int size)
        {
            ComplexVector result = new ComplexVector(size);
            Parallel.For(0, size, (i) => {
                result[i] = Complex.Zero;
            });

            return result;
        }

        /// <summary>
        ///  A vector of complex number that represents one.
        /// </summary>
        public static ComplexVector One(int size)
        {
            ComplexVector result = new ComplexVector(size);
            Parallel.For(0, size, (i) => {
                result[i] = Complex.One;
            });

            return result;
        }

        /// <summary>
        ///  A vector of complex number that represents imaginary one.
        /// </summary>
        public static ComplexVector ImaginaryOne(int size)
        {
            ComplexVector result = new ComplexVector(size);
            Parallel.For(0, size, (i) => {
                result[i] = Complex.ImaginaryOne;
            });

            return result;
        }

        /// <summary>
        /// Fills the complex number vector with specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Init(Complex value)
        {
            ComplexVector result = new ComplexVector(Size);
            Parallel.For(0, Size, (i) => {
                result[i] = value;
            });
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator +(ComplexVector lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] + rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator +(ComplexVector lhs, float rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] + rhs;
            });

            return result;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator +(float lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(rhs.Size);

            Parallel.For(0, rhs.Size, (i) => {
                result[i] = lhs + rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator -(ComplexVector lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] - rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator -(ComplexVector lhs, float rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] - rhs;
            });

            return result;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator -(float lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(rhs.Size);

            Parallel.For(0, rhs.Size, (i) => {
                result[i] = lhs - rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator *(ComplexVector lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] * rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator *(ComplexVector lhs, float rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] * rhs;
            });

            return result;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator *(float lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(rhs.Size);

            Parallel.For(0, rhs.Size, (i) => {
                result[i] = lhs * rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator /(ComplexVector lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] / rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator /(ComplexVector lhs, float rhs)
        {
            ComplexVector result = new ComplexVector(lhs.Size);

            Parallel.For(0, lhs.Size, (i) => {
                result[i] = lhs[i] / rhs;
            });

            return result;
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static ComplexVector operator /(float lhs, ComplexVector rhs)
        {
            ComplexVector result = new ComplexVector(rhs.Size);

            Parallel.For(0, rhs.Size, (i) => {
                result[i] = lhs / rhs[i];
            });

            return result;
        }
        #endregion

        #region Complex Special Functions
        /// <summary>
        /// Computes the absolute value for the vector of complex number.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static ComplexVector Abs(ComplexVector vector)
        {
            ComplexVector result = new ComplexVector(vector.Size);
            Parallel.For(0, vector.Size, (i) => {
                result[i] = Complex.Abs(vector[i]);
            });

            return result;
        }

        /// <summary>
        /// Computes the square root value for the vector of complex number.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static ComplexVector Sqrt(ComplexVector vector)
        {
            ComplexVector result = new ComplexVector(vector.Size);
            Parallel.For(0, vector.Size, (i) => {
                result[i] = Complex.Sqrt(vector[i]);
            });

            return result;
        }

        /// <summary>
        /// Computes the square value for the vector of complex number.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static ComplexVector Square(ComplexVector vector)
        {
            ComplexVector result = new ComplexVector(vector.Size);
            Parallel.For(0, vector.Size, (i) => {
                result[i] = Complex.Pow(vector[i], 2);
            });

            return result;
        }

        /// <summary>
        /// Computes the log value for the vector of complex number.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static ComplexVector Log(ComplexVector vector)
        {
            ComplexVector result = new ComplexVector(vector.Size);
            Parallel.For(0, vector.Size, (i) => {
                result[i] = Complex.Log(vector[i]);
            });

            return result;
        }

        /// <summary>
        /// Computes the exponential value for the vector of complex number.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static ComplexVector Exp(ComplexVector vector)
        {
            ComplexVector result = new ComplexVector(vector.Size);
            Parallel.For(0, vector.Size, (i) => {
                result[i] = Complex.Exp(vector[i]);
            });

            return result;
        }

        /// <summary>
        /// Computes the pow value for the vector of complex number.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static ComplexVector Pow(ComplexVector vector, ComplexVector powerVector)
        {
            ComplexVector result = new ComplexVector(vector.Size);
            Parallel.For(0, vector.Size, (i) => {
                result[i] = Complex.Pow(vector[i], powerVector[i]);
            });

            return result;
        }
        #endregion

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Size; i++)
            {
                result += this[i].ToString();

                result += "\n\n";
            }

            return result;
        }

    }
}
