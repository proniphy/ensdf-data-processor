using AveragingMethods;

namespace ENSDF_Parser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> lines = File.ReadAllLines("data\\Pd106_beta_v2.ens").ToList();

            List<DataSet> sets = Parser.Parse(lines);
            ValueExtractor extractor = new(sets[0]);
            extractor.RemoveInvalidEntries();

            AveragingTool avg = new();

            foreach (var l in extractor.Values)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Level:{l.Key.LevelRecord.E}: ");
                foreach (var g in l.Value)
                {
                    if (g.Value.Count == 0) continue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Gamma:{g.Key.E}");
                    Console.ResetColor();
                    foreach (var v in g.Value)
                    {
                        Console.WriteLine($"{v.Val}±{v.DVal};");
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    avg.Print(g.Value);
                }
            }
        }
    }
}