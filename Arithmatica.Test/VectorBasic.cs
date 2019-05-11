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
            Vector3 a = new Vector3(1);
            a[0] = (1, 2, 1);

            Vector3 b = Vector3.Unit(2, 1, 2);

            var c = Vector3.Dot(a, b);
            c.Print();
        }
    }
}
