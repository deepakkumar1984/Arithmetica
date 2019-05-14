using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    public partial class Sampler
    {
        /// <summary>
        /// Samples are drawn from a binomial distribution with specified parameters, n trials and p probability of success where n an integer >= 0 and p is in the interval [0,1]. (n may be input as a float, but it is truncated to an integer in use)
        /// </summary>
        /// <param name="x">The output array.</param>
        /// <param name="p">The p.</param>
        /// <param name="seed">The seed.</param>
        public static void Bernoulli(ArithArray x, float p, int? seed = null)
            => ArrayOps.RandomBernoulli(x, new SeedSource(seed), p);

        /// <summary>
        /// Draw samples from a standard Cauchy distribution.
        /// The Cauchy distribution arises in the solution to the driven harmonic oscillator problem, and also describes spectral line broadening. It also describes the distribution of values at which a line tilted at a random angle will cut the x axis.
        /// When studying hypothesis tests that assume normality, seeing how the tests perform on data from a Cauchy distribution is a good indicator of their sensitivity to a heavy-tailed distribution, since the Cauchy looks very much like a Gaussian distribution, but with heavier tails.
        /// </summary>
        /// <param name="x">The output array.</param>
        /// <param name="median">The median value.</param>
        /// <param name="sigma">The sigma.</param>
        /// <param name="seed">The seed.</param>
        public static void Cauchy(ArithArray x, float median, float sigma, int? seed = null)
            => ArrayOps.RandomCauchy(x, new SeedSource(seed), median, sigma);

        /// <summary>
        /// Draw samples from an exponential distribution. The exponential distribution is a continuous analogue of the geometric distribution. 
        /// </summary>
        /// <param name="x">The output array.</param>
        /// <param name="lambda">The lambda value.</param>
        /// <param name="seed">The seed.</param>
        public static void Exponential(ArithArray x, float lambda, int? seed = null)
            => ArrayOps.RandomExponential(x, new SeedSource(seed), lambda);

        /// <summary>
        /// Draw samples from the geometric distribution.
        /// Bernoulli trials are experiments with one of two outcomes: success or failure(an example of such an experiment is flipping a coin). 
        /// The geometric distribution models the number of trials that must be run in order to achieve success.It is therefore supported on the positive integers, k = 1, 2, ....
        /// </summary>
        /// <param name="x">The output array.</param>
        /// <param name="p">The probability value.</param>
        /// <param name="seed">The seed.</param>
        public static void Geometric(ArithArray x, float p, int? seed = null)
            => ArrayOps.RandomGeometric(x, new SeedSource(seed), p);

        /// <summary>
        /// Draw samples from a log-normal distribution with specified mean, standard deviation, and array shape. 
        /// <para>Note that the mean and standard deviation are not the values for the distribution itself, but of the underlying normal distribution it is derived from.</para>
        /// </summary>
        /// <param name="x">The output array.</param>
        /// <param name="mean">The mean value.</param>
        /// <param name="std">The standard deviation value.</param>
        /// <param name="seed">The seed.</param>
        public static void LogNormal(ArithArray x, float mean, float std, int? seed = null)
            => ArrayOps.RandomLogNormal(x, new SeedSource(seed), mean, std);

        /// <summary>
        /// Draw random samples from a normal (Gaussian) distribution.
        /// <para>The probability density function of the normal distribution, first derived by De Moivre and 200 years later by both Gauss and Laplace independently[2], is often called the bell curve because of its characteristic shape.</para>
        /// <para>The normal distributions occurs often in nature. For example, it describes the commonly occurring distribution of samples influenced by a large number of tiny, random disturbances, each with its own unique distribution.</para>
        /// </summary>
        /// <param name="x">The output array.</param>
        /// <param name="mean">The mean value.</param>
        /// <param name="std">The standard deviation value.</param>
        /// <param name="seed">The seed.</param>
        public static void Normal(ArithArray x, float mean, float std, int? seed = null)
            => ArrayOps.RandomNormal(x, new SeedSource(seed), mean, std);

        /// <summary>
        /// Samples are uniformly distributed over the half-open interval [min, max) (includes min, but excludes max). 
        /// In other words, any value within the given interval is equally likely to be drawn by uniform.
        /// </summary>
        /// <param name="x">The output.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="seed">The seed.</param>
        public static void Uniform(ArithArray x, float min, float max, int? seed = null)
            => ArrayOps.RandomUniform(x, new SeedSource(seed), min, max);
    }
}
