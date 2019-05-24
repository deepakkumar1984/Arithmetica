using Arithmetica;
using Arithmetica.LinearAlgebra.Single;
using Arithmetica.Quantum;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ArithConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //DotNetPerf();
            //ArithPerf();

            ComplexVector samples = new ComplexVector(Complex.One, Complex.One + Complex.ImaginaryOne, Complex.ImaginaryOne, Complex.One - Complex.ImaginaryOne, Complex.One, Complex.Zero, Complex.ImaginaryOne, Complex.ImaginaryOne);

            var c = new ComplexMatrix(2);

            Console.ReadLine();
        }

        private static void DotNetPerf()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 100000000;
            float[] a = new float[count];
            Parallel.For(0, count, i =>
            {
                a[i] = 2.2558f;
            });

            float[] b = new float[count];
            Parallel.For(0, count, i =>
            {
                b[i] = 4.2551f;
            });

            float[] c = new float[count];
            Parallel.For(0, count, i =>
            {
                c[i] = 9.2551f;
            });
            
            float[] r = new float[count];
            Parallel.For(0, count, i =>
            {
                r[i] = (float)Math.Sin((a[i] + b[i]) * c[i]);
            });

            sw.Stop();

            for(int i=0;i<20;i++)
            {
                Console.WriteLine(r[i] + " ");
            }

            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private static void ArithPerf()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 100000000;
            Vector a = new Vector(count);
            a.Fill(2.2558f);

            Vector b = new Vector(count);
            b.Fill(4.2551f);

            Vector c = new Vector(count);
            c.Fill(9.2551f);

            Vector r = Vector.Sin((a + b) * c);
            sw.Stop();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(r[i] + " ");
            }

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
