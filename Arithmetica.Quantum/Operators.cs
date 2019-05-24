using System;
using System.Collections.Generic;
using System.Text;
using Arithmetica.Quantum.Gate;

namespace Arithmetica.Quantum
{
    public class Operators
    {
        /// <summary>
        /// The Hardmad gate
        /// </summary>
        /// <param name="qubit">The qubit.</param>
        /// <returns></returns>
        public static void H(QuantumRegister qubit)
        {
            qubit.BitRegister = (QGate.HadamardGate * qubit).BitRegister;
        }

        public static void H(QuantumCircuit c)
        {
            foreach (var item in c.Bits)
            {
                H(item);
            }
        }

        public static void X(Qubit qubit)
        {
            qubit.BitRegister = (QGate.NotGate * qubit).BitRegister;
        }

        
        public static Qubit Y(Qubit qubit)
        {
            return (QGate.PauliYGate * qubit).GetQubits()[0];
        }

        public static Qubit Z(Qubit qubit)
        {
            return (QGate.PauliZGate * qubit).GetQubits()[0];
        }

        public static Qubit FG(Qubit qubit)
        {
            return (QGate.FredkinGate * qubit).GetQubits()[0];
        }

        public static Qubit SWAP(Qubit qubit)
        {
            return (QGate.SwapGate * qubit).GetQubits()[0];
        }

        public static Qubit SqrtX(Qubit qubit)
        {
            return (QGate.SquareRootNotGate * qubit).GetQubits()[0];
        }

        public static Qubit SqrtSWAP(Qubit qubit)
        {
            return (QGate.SquareRootSwapGate * qubit).GetQubits()[0];
        }

        public static Qubit S(Qubit qubit, double phase)
        {
            return (QGate.PhaseShiftGate(phase) * qubit).GetQubits()[0];
        }

        public static Qubit T(Qubit qubit)
        {
            return (QGate.ToffoliGate * qubit).GetQubits()[0];
        }

        public static Qubit M(Qubit qubit)
        {
            qubit.Collapse();
            return qubit;
        }

        public static QuantumState State(Qubit qubit)
        {
            QuantumState state = QuantumState.Zero;

            if(qubit.BitRegister[0].Real == 1)
                state = QuantumState.Zero;
            else if (qubit.BitRegister[1].Real == 1)
                state = QuantumState.One;

            if (qubit.BitRegister[0].Real == 1 && qubit.BitRegister[1].Real == 1)
                state = QuantumState.Superposition;

            return state;
        }
    }

    public enum QuantumState
    {
        Zero = 0,
        One = 1,
        Superposition = -1
    }
}
