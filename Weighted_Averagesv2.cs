using System;
using System.Collections.Generic;
using System.Linq;

namespace ENSDF_Parser
{
    // A simple container just for the pure math results
    internal class PureAverageResult
    {
        public double Mean { get; set; }
        public double Uncertainty { get; set; }
    }

    internal static class PureWeightedAverageTool
    {
        /// <summary>
        /// Calculates the textbook weighted average and standard statistical uncertainty.
        /// No physics evaluation rules (LWM, Chi-Squared) are applied.
        /// </summary>
        internal static PureAverageResult Calculate(List<Value> data)
        {
            // Filter out invalid data (missing uncertainties)
            var validData = data.Where(v => v.DVal > 0).ToList();

            if (validData.Count == 0)
            {
                throw new InvalidOperationException("No valid data points to average.");
            }

            double sumWeights = 0;
            double sumWeightTimesValue = 0;

            // Calculate standard weights (w = 1 / sigma^2)
            foreach (var item in validData)
            {
                double weight = 1.0 / (item.DVal * item.DVal);
                sumWeights += weight;
                sumWeightTimesValue += weight * item.Val;
            }

            // Return the pure mathematical mean and standard error
            return new PureAverageResult
            {
                Mean = sumWeightTimesValue / sumWeights,
                Uncertainty = Math.Sqrt(1.0 / sumWeights)
            };
        }
    }
}