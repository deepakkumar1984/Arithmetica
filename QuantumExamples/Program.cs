using NumSharp;
using System;

namespace QuantumExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Global.UseAmplifier(0);
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
