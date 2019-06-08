using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Arithmetica.Quantum
{
    /// <summary>
    /// Circuit result based on the program execution
    /// </summary>
    public class CircuitResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CircuitResult"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<Probability> Result { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitResult"/> class.
        /// </summary>
        public CircuitResult()
        {
            Result = new List<Probability>();
        }

        /// <summary>
        /// Get the result in Json Format.
        /// </summary>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(Result.ToArray(), Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Gets or sets the <see cref="Probability"/> with the specified qvalue.
        /// </summary>
        /// <value>
        /// The <see cref="Probability"/>.
        /// </value>
        /// <param name="qvalue">The qvalue.</param>
        /// <returns></returns>
        public int this[string qvalue]
        {
            get
            {
                Probability result = Result.FirstOrDefault(x => (x.QuantumValue == qvalue));
                if (result == null)
                {
                    result = new Probability() { QuantumValue = qvalue, Count = 0 };
                    Result.Add(result);
                }

                return result.Count;
            }
            set
            {
                Probability result = Result.FirstOrDefault(x => (x.QuantumValue == qvalue));
                if (result == null)
                {
                    result = new Probability() { QuantumValue = qvalue, Count = 0 };
                    Result.Add(result);
                }

                result.Count = value;
            }
        }
    }

    /// <summary>
    /// Probability value result
    /// </summary>
    public class Probability
    {
        public string QuantumValue { get; set; }

        public int Count { get; set; }

        public float Percentage { get; set; } 

        public int ClassicalValue
        {
            get
            {
                return Convert.ToInt32(QuantumValue, 2);
            }
        }
    }
}
