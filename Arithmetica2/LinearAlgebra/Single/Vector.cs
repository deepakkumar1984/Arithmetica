using Arithmetica;
using Arithmetica.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica2.LinearAlgebra.Single
{
    public class Vector : Vector<float>
    {
        public Vector() : base(1)
        {

        }

        public override ArithArray V
        {
            get
            {
                if (IsDirty)
                {
                    if(arithArray != null)
                        arithArray.Dispose();
                    arithArray = new ArithArray(variable.Count, DimLength);
                    arithArray.LoadFrom(variable.ToArray());
                    IsDirty = false;
                }

                return arithArray;
            }
        }
    }
}
