using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.Quantum
{
    public class Transform
    {
        /// <summary>
        /// The Hardmad gate
        /// </summary>
        /// <param name="qubit">The qubit.</param>
        /// <returns></returns>
        public static void H(ref Qubit qubit)
        {
            qubit = (QuantumGate.HadamardGate * qubit).Qubit;
        }

        public static Qubit X(Qubit qubit)
        {
            return (QuantumGate.NotGate * qubit).Qubit;
        }

        public static void CNOT(Qubit q0, Qubit q1)
        {
            q1 = (QuantumGate.ControlledNotGate * new QCRegister(q0, q1)).Qubit;
        }

        public static Qubit Y(Qubit qubit)
        {
            return (QuantumGate.PauliYGate * qubit).Qubit;
        }

        public static Qubit Z(Qubit qubit)
        {
            return (QuantumGate.PauliZGate * qubit).Qubit;
        }

        public static Qubit FG(Qubit qubit)
        {
            return (QuantumGate.FredkinGate * qubit).Qubit;
        }

        public static Qubit SWAP(Qubit qubit)
        {
            return (QuantumGate.SwapGate * qubit).Qubit;
        }

        public static Qubit SqrtX(Qubit qubit)
        {
            return (QuantumGate.SquareRootNotGate * qubit).Qubit;
        }

        public static Qubit SqrtSWAP(Qubit qubit)
        {
            return (QuantumGate.SquareRootSwapGate * qubit).Qubit;
        }

        public static Qubit S(Qubit qubit, double phase)
        {
            return (QuantumGate.PhaseShiftGate(phase) * qubit).Qubit;
        }

        public static Qubit T(Qubit qubit)
        {
            return (QuantumGate.ToffoliGate * qubit).Qubit;
        }

        public static Qubit M(Qubit qubit)
        {
            qubit.Collapse();
            return qubit;
        }

        public static QuantumState State(Qubit qubit)
        {
            QuantumState state = QuantumState.Zero;

            if(qubit.Register[0].Real == 1)
                state = QuantumState.Zero;
            else if (qubit.Register[1].Real == 1)
                state = QuantumState.One;

            if (qubit.Register[0].Real == 1 && qubit.Register[1].Real == 1)
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
