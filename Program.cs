namespace ENSDF_Parser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> lines = File.ReadAllLines("data\\Pd106_beta_v2.ens").ToList();

            bool isEnergyComment = false;
            Dictionary<Level, Dictionary<GammaRecord, List<Value>>> values = new();
            List<DataSet> sets = Parser.Parse(lines);
            foreach (var l in sets[0].Levels)
            {
                foreach (var g in l.Data.GammaRecords)
                {
                    foreach (var c in g.Comments)
                    {
                        if (c.RType.C2 == 'c')
                        {
                            if (c.CTEXT.Contains("E$") || isEnergyComment)
                            {
                                if(c.CTEXT.Contains("$") && !c.CTEXT.Contains("E$"))
                                {
                                    isEnergyComment = false;
                                    continue;
                                }
                                isEnergyComment = true;

                                string[] data = c.CTEXT.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                for (int i = 0; i < data.Length; i++)
                                {
                                    if (data[i] == "E$") continue;
                                    if (data[i] == "Other:") break;
                                    double energy;
                                    if (double.TryParse(data[i], out energy))
                                    {
                                        Value val = new Value() { Val = energy };
                                        if(i + 1 < data.Length)
                                        {
                                            if(data[i + 1].Contains("I"))
                                            {
                                                val.DVal = double.Parse(data[i + 1].Replace("{I", "").Replace("}", ""));
                                                i++;
                                            }
                                        }
                                        if (!values.ContainsKey(l)) values.Add(l, new Dictionary<GammaRecord, List<Value>>());
                                        if (!values[l].ContainsKey(g)) values[l].Add(g, new List<Value>());
                                        values[l][g].Add(val);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach(var l in values)
            {
                foreach(var g in l.Value)
                {
                    Console.WriteLine($"Values for Level:{l.Key.LevelRecord.E} and Gamma:{g.Key.E}");
                    foreach(var v in g.Value)
                    {
                        Console.WriteLine($"{v.Val}±{v.DVal}");
                    }
                }
            }
        }
    }
}