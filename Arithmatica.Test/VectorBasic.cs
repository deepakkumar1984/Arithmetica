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
            //Create 3D vector of 1 size
            Vector3 a = new Vector3(1);
            //Assign the x,y,z of the vector
            a[0] = (1, 2, 1);

            //Create a unit with x,y,z
            Vector3 b = Vector3.Unit(2, 1, 2);

            //Dot product
            var c = Vector3.Dot(a, b);
            c.Print();
        }
    }
}
