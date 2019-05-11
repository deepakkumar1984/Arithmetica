using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Quaternion
    {
        public static Quaternion Sin(Quaternion src) => Quaternion.Out(ArrayOps.Sin(src.variable));
        
        public static Quaternion Cos(Quaternion src) => Quaternion.Out(ArrayOps.Cos(src.variable));

        public static Quaternion Tan(Quaternion src) => Quaternion.Out(ArrayOps.Tan(src.variable));

        public static Quaternion Asin(Quaternion src) => Quaternion.Out(ArrayOps.Asin(src.variable));
       
        public static Quaternion Acos(Quaternion src) => Quaternion.Out(ArrayOps.Acos(src.variable));
        
        public static Quaternion Atan(Quaternion src) => Quaternion.Out(ArrayOps.Atan(src.variable));

        public static Quaternion Atan2(Quaternion srcY, Quaternion srcX) => Quaternion.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        public static Quaternion Sinh(Quaternion src) => Quaternion.Out(ArrayOps.Sinh(src.variable));
        
        public static Quaternion Cosh(Quaternion src) => Quaternion.Out(ArrayOps.Cosh(src.variable));
      
        public static Quaternion Tanh(Quaternion src) => Quaternion.Out(ArrayOps.Tanh(src.variable));


    }
}
