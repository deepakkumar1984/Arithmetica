using Arithmetica;
using Arithmetica.LinearAlgebra.Single;
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
            Vector3 a = new Vector3(1, 2, 3);

            //Create a unit with x,y,z
            Vector3 b = new Vector3(2, 1, 2);

            //Dot product
            var c = Vector3.CrossProduct(a, b);
        }
    }
}
