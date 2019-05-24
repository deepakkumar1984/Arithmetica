using System;
using System.Collections.Generic;
using System.Text;

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
            qubit.Variable = (QGate.HadamardGate * qubit).Variable;
        }

        public static void H(Circuit c)
        {
            foreach (var item in c.Bits)
            {
                H(item);
            }
        }

        public static void X(Qubit qubit)
        {
            qubit.Variable = (QGate.NotGate * qubit).Variable;
        }

        
        public static Qubit Y(Qubit qubit)
        {
            return (QGate.PauliYGate * qubit).Qubit;
        }

        public static Qubit Z(Qubit qubit)
        {
            return (QGate.PauliZGate * qubit).Qubit;
        }

        public static Qubit FG(Qubit qubit)
        {
            return (QGate.FredkinGate * qubit).Qubit;
        }

        public static Qubit SWAP(Qubit qubit)
        {
            return (QGate.SwapGate * qubit).Qubit;
        }

        public static Qubit SqrtX(Qubit qubit)
        {
            return (QGate.SquareRootNotGate * qubit).Qubit;
        }

        public static Qubit SqrtSWAP(Qubit qubit)
        {
            return (QGate.SquareRootSwapGate * qubit).Qubit;
        }

        public static Qubit S(Qubit qubit, double phase)
        {
            return (QGate.PhaseShiftGate(phase) * qubit).Qubit;
        }

        public static Qubit T(Qubit qubit)
        {
            return (QGate.ToffoliGate * qubit).Qubit;
        }

        public static Qubit M(Qubit qubit)
        {
            qubit.Collapse();
            return qubit;
        }

        public static QuantumState State(Qubit qubit)
        {
            QuantumState state = QuantumState.Zero;

            if(qubit.Variable[0].Real == 1)
                state = QuantumState.Zero;
            else if (qubit.Variable[1].Real == 1)
                state = QuantumState.One;

            if (qubit.Variable[0].Real == 1 && qubit.Variable[1].Real == 1)
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
