using Arithmetica;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmatica.Test
{
    [TestClass]
    public class MatrixBasic
    {
        [TestMethod]
        public void CreateVar()
        {
            Matrix a = new Matrix(4, 6);
            a.Fill(1);

            Matrix b = new Matrix(4, 6);
            b.Fill(2);

            var m = Matrix.Matrix4x4();

            Matrix c = Matrix.Sin(a + b);
            c.Print();
        }
    }
}
