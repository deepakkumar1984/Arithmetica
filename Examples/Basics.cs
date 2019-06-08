using Arithmetica.LinearAlgebra.Single;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class Basics : IExample
    {
        public void Run()
        {
            //Create a float vector loaded with array
            SingleVector a = SingleVector.LoadArray(1, 2, 3, 4, 5, 6);

            //Create a float vector with constant value
            SingleVector b = new SingleVector(6);
            b.Fill(2.5f);

            //Perform the math calculation y = sin(a) + exp(b)
            SingleVector y = SingleVector.Sin(a) + SingleVector.Exp(b);
            y.Print();
        }
    }
}
