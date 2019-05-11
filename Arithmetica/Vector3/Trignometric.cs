using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Vector3
    {
        public static Vector3 Sin(Vector3 src) => Vector3.Out(ArrayOps.Sin(src.variable));
        
        public static Vector3 Cos(Vector3 src) => Vector3.Out(ArrayOps.Cos(src.variable));

        public static Vector3 Tan(Vector3 src) => Vector3.Out(ArrayOps.Tan(src.variable));

        public static Vector3 Asin(Vector3 src) => Vector3.Out(ArrayOps.Asin(src.variable));
       
        public static Vector3 Acos(Vector3 src) => Vector3.Out(ArrayOps.Acos(src.variable));
        
        public static Vector3 Atan(Vector3 src) => Vector3.Out(ArrayOps.Atan(src.variable));

        public static Vector3 Atan2(Vector3 srcY, Vector3 srcX) => Vector3.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        public static Vector3 Sinh(Vector3 src) => Vector3.Out(ArrayOps.Sinh(src.variable));
        
        public static Vector3 Cosh(Vector3 src) => Vector3.Out(ArrayOps.Cosh(src.variable));
      
        public static Vector3 Tanh(Vector3 src) => Vector3.Out(ArrayOps.Tanh(src.variable));


    }
}
