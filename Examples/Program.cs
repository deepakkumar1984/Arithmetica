using System;
using Arithmetica.Geometry2D;
using Arithmetica.LinearAlgebra.Single;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumberExample();
            //Point A in the 2D space
            Vector2 A = new Vector2(10, 20);

            //Point B in the 2D space
            Vector2 B = new Vector2(70, 80);

            //Find the Euclidean distance
            var distance = DistanceMethods.Distance(A, B);
        }

        static void ComplexNumberExample()
        {
            //Define a 2x2 complex matrix
            ComplexMatrix matrix = new ComplexMatrix(2, 2);
            matrix[0, 0] = new Complex(2, 2);
            matrix[0, 1] = new Complex(1, 2);
            matrix[1, 0] = new Complex(3, 1);
            matrix[1, 1] = new Complex(2, 3);
            Console.WriteLine("First Matrix");
            Console.WriteLine(matrix.ToString());
            
            //Define a comple vector of length 2
            ComplexVector vector = new ComplexVector(2);
            vector[0] = new Complex(2, 1);
            vector[1] = new Complex(1, 3);
            Console.WriteLine("Second Vector");
            Console.WriteLine(vector.ToString());

            // Multiplying a 2x2 matrix with a vector will result a vector
            var result = matrix * vector;

            Console.WriteLine("Result Vector");
            Console.WriteLine(result.ToString());
        }
    }
}
