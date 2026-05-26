using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AveragingMethods
{
    public class AveragingTool
    {
        public AveragingTool()
        {
            Methods.Add(WeightedMean);
            Methods.Add(LimitedWeightMean);
            Methods.Add(NormalizedResidualMethod);
            Methods.Add(GaussianConsensusAveraging);
        }

        List<IAverageMethod> Methods = new List<IAverageMethod>();

        public WeightedMean WeightedMean { get; } = new WeightedMean();
        public LimitedWeightMean LimitedWeightMean { get; } = new LimitedWeightMean();
        public NormalizedResidualMethod NormalizedResidualMethod { get; } = new NormalizedResidualMethod();
        public GaussianConsensusAveraging GaussianConsensusAveraging { get; } = new GaussianConsensusAveraging();

        public void Print(List<Value> values)
        {
            for (int i = 0; i < Methods.Count; i++)
            {
                var result = Methods[i].Compute(values);
                Console.WriteLine($"{Methods[i].Name}: {result.Mean:0.00} ± {result.Sigma:0.00};");
            }
        }
    }
}
