using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetica.Quantum.Gate
{
    /// <summary>
    /// Base class for the Quantum gate implementation
    /// </summary>
    public abstract class QuantumGate
    {
        /// <summary>
        /// Gets or sets the name of the gate
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the matrix which will transform the qubit
        /// </summary>
        /// <value>
        /// The matrix.
        /// </value>
        public ComplexMatrix Matrix { get; set; }

        /// <summary>
        /// Gets or sets the state of the apply.
        /// </summary>
        /// <value>
        /// The state of the apply.
        /// </value>
        public QubitState? ApplyState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumGate" /> class.
        /// </summary>
        /// <param name="applyState">Apply the gate if the qubit state match.</param>
        /// <param name="name">The name.</param>
        public QuantumGate(string name, QubitState? applyState = null)
        {
            Name = name;
            ApplyState = applyState;
        }

        /// <summary>
        /// Appliy the gate to the one or more qubit
        /// </summary>
        /// <param name="qubits">The qubits.</param>
        public virtual void Apply(params Qubit[] qubits)
        {
            Parallel.For(0, qubits.Length, (i) => {
                bool run = true;
                if (ApplyState.HasValue)
                {
                    run = qubits[i].QState == ApplyState.Value;
                }

                qubits[i].BitRegister = ComplexMatrix.Multiply(Matrix, qubits[i].BitRegister);
            });
        }

        /// <summary>
        /// Internal method to get the controlled gate
        /// </summary>
        /// <param name="gateMatrix">The gate matrix.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">A controlled gate can only be created from a unary gate.</exception>
        internal ComplexMatrix ControlledGateMatrix(ComplexMatrix gateMatrix)
        {
            if (gateMatrix.ColumnCount != 2 || gateMatrix.RowCount != 2)
            {
                throw new ArgumentException("A controlled gate can only be created from a unary gate.");
            }

            return new Complex[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, gateMatrix[0, 0], gateMatrix[0, 1] },
                { 0, 0, gateMatrix[1, 0], gateMatrix[1, 1] },
            };
        }
    }
}
