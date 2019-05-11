using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Plane
    {
        public static Plane Sin(Plane src) => Plane.Out(ArrayOps.Sin(src.variable));
        
        public static Plane Cos(Plane src) => Plane.Out(ArrayOps.Cos(src.variable));

        public static Plane Tan(Plane src) => Plane.Out(ArrayOps.Tan(src.variable));

        public static Plane Asin(Plane src) => Plane.Out(ArrayOps.Asin(src.variable));
       
        public static Plane Acos(Plane src) => Plane.Out(ArrayOps.Acos(src.variable));
        
        public static Plane Atan(Plane src) => Plane.Out(ArrayOps.Atan(src.variable));

        public static Plane Atan2(Plane srcY, Plane srcX) => Plane.Out(ArrayOps.Atan2(srcY.variable, srcX.variable));

        public static Plane Sinh(Plane src) => Plane.Out(ArrayOps.Sinh(src.variable));
        
        public static Plane Cosh(Plane src) => Plane.Out(ArrayOps.Cosh(src.variable));
      
        public static Plane Tanh(Plane src) => Plane.Out(ArrayOps.Tanh(src.variable));


    }
}
