using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    public class ControlledNot : QuantumGate
    {
        public ControlledNot() : base("CNOT")
        {
            Matrix = new Complex[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, Matrix[0, 0], Matrix[0, 1] },
                { 0, 0, Matrix[1, 0], Matrix[1, 1] },
            };
        }

        public override void Apply(QuantumRegister register)
        {
            PauliX notGate = new PauliX();
            notGate.Apply(register);
            base.Apply(register);
        }
    }
}
