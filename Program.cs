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

                                if (c.CTEXT.Contains("Other")) isEnergyComment = false;
                                string[] raw_data = c.CTEXT.Split("Other", StringSplitOptions.RemoveEmptyEntries);
                                if (raw_data.Length == 1 && isEnergyComment == false) continue;
                                string[] data = raw_data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                                for (int i = 0; i < data.Length; i++)
                                {                                    
                                    if (data[i] == "E$") continue;
                                    if (data[i].Contains(",")) continue;
                                    double energy;
                                    if (double.TryParse(data[i], out energy))
                                    {
                                        Value val = new Value();
                                        val.SetValue(data[i]);
                                        if(i + 1 < data.Length)
                                        {
                                            double dVal;
                                            if (data[i + 1].Contains("I"))
                                            {
                                                val.DVal = double.Parse(data[i + 1].Replace("{I", "").Replace("}", ""));
                                                i++;
                                            }
                                            else if (double.TryParse(data[i + 1], out dVal))
                                            {
                                                Console.WriteLine($"Missing {{I...}} for Level: {l.LevelRecord.E} and Gamma: {g.E}!");
                                                val.DVal = dVal;
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
            foreach (var l in values)
            {
                foreach(var g in l.Value)
                {
                    foreach(var v in g.Value)
                    {
                        if (v.DVal == 0)
                        {
                            Console.WriteLine($"Value with missing uncertainty for Level:{l.Key.LevelRecord.E} and Gamma:{g.Key.E}: {v.Val}±{v.DVal};");
                        }
                    }
                }
            }
        }
    }
}