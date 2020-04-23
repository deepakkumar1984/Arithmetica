using System;

namespace QuantumExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string runEx = "0";
            IExample example = null;
            switch (runEx)
            {
                case "0":
                example = new Superposition();
                    break;

                default:
                    break;
            }

            example.Run();
            
            Console.ReadLine();
        }
    }
}
