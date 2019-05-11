﻿using Arithmetica;
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

            Matrix.Identity(3).Print();
            Matrix.Diagonal(1, 2, 3).Print();
            
            Console.ReadLine();
        }

        private static void DotNetPerf()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 100000000;
            float[] a = new float[count];
            Parallel.For(0, count, i => {
                a[i] = 2.2558f;
            });

            float[] b = new float[count];
            Parallel.For(0, count, i => {
                b[i] = 4.2551f;
            });

            float[] c = new float[count];
            Parallel.For(0, count, i => {
                c[i] = 9.2551f;
            });

            float[] r = new float[count];
            Parallel.For(0, count, i => {
                r[i] = (float)Math.Sqrt(Math.Abs(a[i]) + Math.Pow(b[i], 2) * Math.Tanh(b[i]) * Math.Cos(c[i]));
            });

            Parallel.For(0, count, i =>
            {
                r[i] = (float)Math.Exp(r[i]);
            });

            double final = 0;
            Parallel.For(0, count, i =>
            {
                final += r[i];
            });


            sw.Stop();

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

            Vector r = Vector.Sqrt(Vector.Abs(a) + Vector.Square(b)) * Vector.Tanh(b) * Vector.Cos(c);
            r = Vector.Exp(r);

            Vector final = Vector.Sum(r);
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}