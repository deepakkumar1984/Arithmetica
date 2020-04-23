using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.QuantumGates
{
    /// <summary>
    /// The Fredkin gate (also CSWAP gate) is a computational circuit suitable for reversible computing, invented by Edward Fredkin. 
    /// It is universal, which means that any logical or arithmetic operation can be constructed entirely of Fredkin gates. 
    /// The Fredkin gate is a circuit or device with three inputs and three outputs that transmits the first bit unchanged and swaps the last two bits if, and only if, the first bit is 1.
    /// <para>
    /// Wikipedia: https://en.wikipedia.org/wiki/Fredkin_gate
    /// </para>
    /// </summary>
    /// <seealso cref="Arithmetica.QuantumGates.QuantumGate" />
    public class Fredkin : QuantumGate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fredkin"/> class.
        /// </summary>
        public Fredkin() : base("F")
        {
            Matrix = new Complex[,]{
                    { 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1 },
                };
        }

        /// <summary>
        /// Appliy the gate to the one or more qubit
        /// </summary>
        /// <param name="qubits">The qubits.</param>
        public override void Apply(params Qubit[] qubits)
        {
            var reg = new QuantumRegister(qubits);
            var result = QuantumRegister.GetQubits(ComplexMatrix.Multiply(Matrix, reg.BitRegister));
            for (int i = 0; i < qubits.Length; i++)
                qubits[i].BitRegister = result[i].BitRegister;
        }
    }
}
