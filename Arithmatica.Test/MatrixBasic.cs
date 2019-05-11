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
            Matrix a = new Matrix(4, 6, DType.Float32);
            a.Fill(1);

            Matrix b = new Matrix(4, 6, DType.Float32);
            b.Fill(2);

            Matrix c = AM.Sin(a + b);
            c.Print();
        }
    }
}
