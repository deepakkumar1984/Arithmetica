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
        public static void H(Qubit qubit)
        {
            qubit.BitRegister = (QGate.HadamardGate * qubit).BitRegister;
        }

        public static void H(QuantumCircuit c)
        {
            foreach (var item in c.Register.Qubits)
            {
                H(item);
            }
        }

        public static void X(Qubit qubit)
        {
            qubit = (QGate.NotGate * qubit);
        }

        
        public static Qubit Y(Qubit qubit)
        {
            return (QGate.PauliYGate * qubit);
        }

        public static Qubit Z(Qubit qubit)
        {
            return (QGate.PauliZGate * qubit);
        }

        public static Qubit FG(Qubit qubit)
        {
            return (QGate.FredkinGate * qubit);
        }

        public static Qubit SWAP(Qubit qubit)
        {
            return (QGate.SwapGate * qubit);
        }

        public static Qubit SqrtX(Qubit qubit)
        {
            return (QGate.SquareRootNotGate * qubit);
        }

        public static Qubit SqrtSWAP(Qubit qubit)
        {
            return (QGate.SquareRootSwapGate * qubit);
        }

        public static Qubit S(Qubit qubit, double phase)
        {
            return (QGate.PhaseShiftGate(phase) * qubit);
        }

        public static Qubit T(Qubit qubit)
        {
            return (QGate.ToffoliGate * qubit);
        }

        public static Qubit M(Qubit qubit)
        {
            qubit.Collapse();
            return qubit;
        }

        public static QubitState State(Qubit qubit)
        {
            QubitState state = QubitState.Zero;

            if(qubit.BitRegister[0].Real == 1)
                state = QubitState.Zero;
            else if (qubit.BitRegister[1].Real == 1)
                state = QubitState.One;

            if (qubit.BitRegister[0].Real == 1 && qubit.BitRegister[1].Real == 1)
                state = QubitState.Superposition;

            return state;
        }
    }

    public enum QubitState
    {
        Zero = 0,
        One = 1,
        Superposition = -1
    }
}
