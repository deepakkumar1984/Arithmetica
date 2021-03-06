﻿using Arithmetica.QuantumGates;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Arithmetica
{
    /// <summary>
    /// Qubit is a quantum bit which can hold value |0> and |1>
    /// </summary>
    public class Qubit
    {
        /// <summary>
        /// Vector representation of a quantum register
        /// </summary>
        /// <value>
        /// The register.
        /// </value>
        public ComplexVector BitRegister { get; set; }

        /// <summary>
        /// Gets or sets the entangled.
        /// </summary>
        /// <value>
        /// The entangled.
        /// </value>
        internal Qubit Entangled { get; set; }

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
                return BitRegister[0];
            }
            private set
            {
                this.BitRegister[0] = value;
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
                return this.BitRegister[1];
            }
            private set
            {
                this.BitRegister[1] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Qubit"/> class. Constructor from probability amplitudes
        /// </summary>
        /// <param name="zeroAmplitude">The zero amplitude.</param>
        /// <param name="oneAmplitude">The one amplitude.</param>
        public Qubit(Complex zeroAmplitude, Complex oneAmplitude)
        {
            BitRegister = new ComplexVector(2);
            BitRegister[0] = zeroAmplitude;
            BitRegister[1] = oneAmplitude;
            Normalize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Qubit"/> class. Constructor from parts of probability amplitudes
        /// </summary>
        /// <param name="zeroAmplitudeReal">The zero amplitude real.</param>
        /// <param name="zeroAmplitudeImaginary">The zero amplitude imaginary.</param>
        /// <param name="oneAmplitudeReal">The one amplitude real.</param>
        /// <param name="oneAmplitudeImaginary">The one amplitude imaginary.</param>
        public Qubit(float zeroAmplitudeReal, float zeroAmplitudeImaginary, float oneAmplitudeReal, float oneAmplitudeImaginary) 
            : this(new Complex(zeroAmplitudeReal, zeroAmplitudeImaginary), new Complex(oneAmplitudeReal, oneAmplitudeImaginary)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Qubit"/> class. Constructor from Bloch sphere coordinates
        /// </summary>
        /// <param name="colatitude">The colatitude.</param>
        /// <param name="longitude">The longitude.</param>
        public Qubit(float colatitude, float longitude) 
            : this(Math.Cos(colatitude / 2), Math.Sin(colatitude / 2) * QCUtil.ComplexExp(Complex.ImaginaryOne * longitude)) { }

        /// <summary>
        ///  Normalizes a qubit
        /// </summary>
        protected void Normalize()
        {
            BitRegister.Normalize();
            if (this.ZeroAmplitude.Phase != 0)
            {
                this.ZeroAmplitude = this.ZeroAmplitude * Complex.FromPolarCoordinates(1, -this.ZeroAmplitude.Phase);
                this.OneAmplitude = this.OneAmplitude * Complex.FromPolarCoordinates(1, -this.ZeroAmplitude.Phase);
            }
        }

        /// <summary>
        /// Collapses a quantum register into a pure state
        /// </summary>
        internal void Collapse()
        {
            Random rand = new Random();
            ComplexVector collapsed = new ComplexVector(BitRegister.Size);
            double probabilityThreshold = QCUtil.Random.NextDouble();

            if (QState == QubitState.Superposition)
            {
                if (probabilityThreshold < 0.5)
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

            if (Entangled != null)
            {
                if(QState == QubitState.One)
                    new ControlledNot().Apply(this, Entangled);
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

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public QubitState QState
        {
            get
            {
                QubitState state = QubitState.Zero;
                if (ZeroAmplitude.ModulusSquared() == 1 && OneAmplitude.ModulusSquared() == 0)
                {
                    state = QubitState.Zero;
                }
                else if (OneAmplitude.ModulusSquared() == 1 && ZeroAmplitude.ModulusSquared() == 0)
                {
                    state = QubitState.One;
                }

                if (ZeroAmplitude.ModulusSquared() != 0 && OneAmplitude.ModulusSquared() != 0)
                {
                    state = QubitState.Superposition;
                }

                return state;
            }
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        internal int[] Values
        {
            get
            {
                if (QState == QubitState.Zero)
                    return new int[] { 0 };
                else if (QState == QubitState.One)
                    return new int[] { 1 };
                else if (QState == QubitState.Superposition)
                    return new int[] { 0, 1 };

                return null;
            }
        }

        /// <summary>
        /// Indicate if the qubit in + reference state
        /// </summary>
        /// <value></value>
        public bool IsPlus
        {
            get
            {
                return ZeroAmplitude.Real > 0 || OneAmplitude.Real > 0;
            }
        }

        // <summary>
        /// Indicate if the qubit in - reference state
        /// </summary>
        /// <value></value>
        public bool IsMinus
        {
            get
            {
                return ZeroAmplitude.Real < 0 || OneAmplitude.Real < 0;
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

            for (int i = 0; i < BitRegister.Size; i++)
            {
                Complex amplitude = BitRegister[i];

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
                    }

                    representation += complexString + "|" + Convert.ToString(i, 2) + ">" + " ";
                }
            }

            return representation;
        }
    }

    /// <summary>
    /// State of the qubit: Zero, One, Superposition
    /// </summary>
    public enum QubitState
    {
        Zero = 0,
        One = 1,
        Superposition = -1
    }
}
