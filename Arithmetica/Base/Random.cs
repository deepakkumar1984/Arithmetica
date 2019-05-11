using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Rnd
    {
        public static void Bernoulli(ArithArray src, float p, int? seed = null)
            => ArrayOps.RandomBernoulli(src, new SeedSource(seed), p);
        
        public static void Cauchy(ArithArray src, float median, float sigma, int? seed = null)
            => ArrayOps.RandomCauchy(src, new SeedSource(seed), median, sigma);

        public static void Exponential(ArithArray src, float lambda, int? seed = null)
            => ArrayOps.RandomExponential(src, new SeedSource(seed), lambda);

        public static void Geometric(ArithArray src, float p, int? seed = null)
            => ArrayOps.RandomGeometric(src, new SeedSource(seed), p);

        public static void LogNormal(ArithArray src, float mean, float std, int? seed = null)
            => ArrayOps.RandomLogNormal(src, new SeedSource(seed), mean, std);

        public static void Normal(ArithArray src, float mean, float std, int? seed = null)
            => ArrayOps.RandomNormal(src, new SeedSource(seed), mean, std);

        public static void Uniform(ArithArray src, float min, float max, int? seed = null)
            => ArrayOps.RandomUniform(src, new SeedSource(seed), min, max);
    }
}
