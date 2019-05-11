using Arithmetica;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmatica.Test
{
    [TestClass]
    public class VectorBasic
    {
        [TestMethod]
        public void CreateVar()
        {
            Vector a = new Vector(5, DType.Float32);
            a.Fill(1);

            Vector b = new Vector(5, DType.Float32);
            b.Fill(2);

            Vector c = AM.Sin(a + b);
            c.Print();
        }
    }
}
