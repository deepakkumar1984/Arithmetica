using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    /// <summary>
    /// Qubit is a quantum bit which can hold value |0> and |1>
    /// </summary>
    /// <seealso cref="Arithmetica.Quantum.QCRegister" />
    public class Qubit : QCRegister
    {
        /// <summary>
        /// Probability amplitude for state |0>
        /// </summary>
        /// <value>
        /// The zero amplitude.
        /// </value>
        public Complex ZeroAmplitude
        {
            get
            {
                return this.Register.Get(0);
            }
            private set
            {
                this.Register.Set(0, value);
            }
        }

        /// <summary>
        /// Probability amplitude for state |1>
        /// </summary>
        /// <value>
        /// The one amplitude.
        /// </value>
        public Complex OneAmplitude
        {
            get
            {
                return this.Register.Get(1);
            }
            private set
            {
                this.Register.Set(1, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Qubit"/> class. Constructor from probability amplitudes
        /// </summary>
        /// <param name="zeroAmplitude">The zero amplitude.</param>
        /// <param name="oneAmplitude">The one amplitude.</param>
        public Qubit(Complex zeroAmplitude, Complex oneAmplitude) : base(zeroAmplitude, oneAmplitude) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Qubit"/> class. Constructor from parts of probability amplitudes
        /// </summary>
        /// <param name="zeroAmplitudeReal">The zero amplitude real.</param>
        /// <param name="zeroAmplitudeImaginary">The zero amplitude imaginary.</param>
        /// <param name="oneAmplitudeReal">The one amplitude real.</param>
        /// <param name="oneAmplitudeImaginary">The one amplitude imaginary.</param>
        public Qubit(float zeroAmplitudeReal, float zeroAmplitudeImaginary, float oneAmplitudeReal, float oneAmplitudeImaginary) 
            : base(new Complex(zeroAmplitudeReal, zeroAmplitudeImaginary), new Complex(oneAmplitudeReal, oneAmplitudeImaginary)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Qubit"/> class. Constructor from Bloch sphere coordinates
        /// </summary>
        /// <param name="colatitude">The colatitude.</param>
        /// <param name="longitude">The longitude.</param>
        public Qubit(float colatitude, float longitude) 
            : base(Math.Cos(colatitude / 2), Math.Sin(colatitude / 2) * QCUtil.ComplexExp(Complex.ImaginaryOne * longitude)) { }

        /// <summary>
        ///  Normalizes a qubit
        /// </summary>
        protected void Normalize()
        {
            Register.Normalize();
            if (this.ZeroAmplitude.Phase != 0)
            {
                this.ZeroAmplitude = this.ZeroAmplitude * Complex.FromPolarCoordinates(1, -this.ZeroAmplitude.Phase);
                this.OneAmplitude = this.OneAmplitude * Complex.FromPolarCoordinates(1, -this.ZeroAmplitude.Phase);
            }
        }

        /// <summary>
        /// Qubit Zero |0>
        /// </summary>
        /// <value>
        /// The zero.
        /// </value>
        public static Qubit Zero
        {
            get
            {
                return new Qubit(Complex.One, Complex.Zero);
            }
        }

        /// <summary>
        /// Qubit Zero |1>
        /// </summary>
        /// <value>
        /// The one.
        /// </value>
        public static Qubit One
        {
            get
            {
                return new Qubit(Complex.Zero, Complex.One);
            }
        }
    }
}
