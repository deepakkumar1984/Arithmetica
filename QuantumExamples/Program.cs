using System;

namespace QuantumExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Superposition.Run();
            QuantumBellTest.Run();
            Teleportation.Run();
            
            Console.ReadLine();
        }
    }
}
