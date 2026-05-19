using System;
using System.Collections.Generic;
using System.Linq;

namespace ENSDF_Parser
{
    internal class AveragingResult
    {
        public double WeightedMean { get; set; }
        public double InternalUncertainty { get; set; }
        public double ExternalUncertainty { get; set; }
        public double ReducedChiSquared { get; set; }
        public double CriticalChiSquared { get; set; }
        public bool IsDiscrepant { get; set; }
    }

    internal static class AveragingTool
    {
        // Precomputed 95% Confidence Level Critical Chi-Square values divided by DOF.
        // Index corresponds to Degrees of Freedom (N-1). Index 0 is a placeholder.
        private static readonly double[] CriticalReducedChiSq95 = new double[]
        {
            0.000, 3.841, 2.996, 2.605, 2.372, 2.214, 2.099, 2.010, 1.938, 1.880, 1.831,
            1.789, 1.752, 1.720, 1.692, 1.666, 1.644, 1.623, 1.604, 1.587, 1.571,
            1.556, 1.543, 1.530, 1.518, 1.507, 1.497, 1.487, 1.478, 1.470, 1.462
        };

        internal static AveragingResult CalculateWeightedAverage(List<Value> data)
        {
            // Filter out invalid data (missing uncertainties)
            var validData = data.Where(v => v.DVal > 0).ToList();

            int n = validData.Count;
            if (n < 2)
            {
                throw new InvalidOperationException("Need at least 2 valid data points to calculate an average.");
            }

            int dof = n - 1;

            // 1. Calculate weights and sum of weights
            double sumWeights = 0;
            double sumWeightTimesValue = 0;

            foreach (var item in validData)
            {
                double weight = 1.0 / (item.DVal * item.DVal);
                sumWeights += weight;
                sumWeightTimesValue += weight * item.Val;
            }

            // 2. Weighted Mean
            double weightedMean = sumWeightTimesValue / sumWeights;

            // 3. Internal Uncertainty
            double internalUnc = Math.Sqrt(1.0 / sumWeights);

            // 4. Reduced Chi-Squared
            double chiSquared = 0;
            foreach (var item in validData)
            {
                double weight = 1.0 / (item.DVal * item.DVal);
                chiSquared += weight * Math.Pow(item.Val - weightedMean, 2);
            }
            double reducedChiSq = chiSquared / dof;

            // 5. External Uncertainty
            double externalUnc = internalUnc;
            if (reducedChiSq > 1.0)
            {
                externalUnc = internalUnc * Math.Sqrt(reducedChiSq);
            }

            // 6. Check against Critical Chi-Squared table
            double criticalValue = dof < CriticalReducedChiSq95.Length
                ? CriticalReducedChiSq95[dof]
                : 1.0; // Fallback for highly massive datasets

            return new AveragingResult
            {
                WeightedMean = weightedMean,
                InternalUncertainty = internalUnc,
                ExternalUncertainty = externalUnc,
                ReducedChiSquared = reducedChiSq,
                CriticalChiSquared = criticalValue,
                IsDiscrepant = reducedChiSq > criticalValue
            };
        }
    }
}