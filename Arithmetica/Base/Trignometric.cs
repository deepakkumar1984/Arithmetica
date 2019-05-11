using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class AM
    {
        public static ArithArray Sin(ArithArray src) => ArrayOps.Sin(src);
        
        public static ArithArray Cos(ArithArray src) => ArrayOps.Cos(src);

        public static ArithArray Tan(ArithArray src) => ArrayOps.Tan(src);

        public static ArithArray Asin(ArithArray src) => ArrayOps.Asin(src);
       
        public static ArithArray Acos(ArithArray src) => ArrayOps.Acos(src);
        
        public static ArithArray Atan(ArithArray src) => ArrayOps.Atan(src);

        public static ArithArray Atan2(ArithArray srcY, ArithArray srcX) => ArrayOps.Atan2(srcY, srcX);

        public static ArithArray Sinh(ArithArray src) => ArrayOps.Sinh(src);
        
        public static ArithArray Cosh(ArithArray src) => ArrayOps.Cosh(src);
      
        public static ArithArray Tanh(ArithArray src) => ArrayOps.Tanh(src);


    }
}
