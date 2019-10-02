using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public class Randomizer
    {
        public static void RandomNormal(NDArray x, float mean, float std, int? seed = null)
        {
            x = np.random.random_sample(new Shape(x.shape));
        }

        public static void RandomBernoulli(NDArray x, float p, int? seed = null)
        {
            x = np.random.random_sample(new Shape(x.shape));
        }

        public static void RandomCauchy(NDArray x, float median, float sigma, int? seed = null)
        {
            x = np.random.random_sample(new Shape(x.shape));
        }

        public static void RandomExponential(NDArray x, float lambda, int? seed = null)
        {
            x = np.random.random_sample(new Shape(x.shape));
        }

        public static void RandomGeometric(NDArray x, float p, int? seed = null)
        {
            x = np.random.random_sample(new Shape(x.shape));
        }

        public static void RandomLogNormal(NDArray x, float mean, float std, int? seed = null)
        {
            x = np.random.random_sample(new Shape(x.shape));
        }

        public static void RandomUniform(NDArray x, float min, float max, int? seed = null)
        {
            x = np.random.random_sample(new Shape(x.shape));
        }
    }
}
