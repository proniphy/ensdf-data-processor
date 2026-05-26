using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSDF_Parser
{
    public class AlphaRecord : Record
    {
        public AlphaRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            E = line.Substring(9, 10).Replace(" ", "");
            DE = line.Substring(19, 2).Replace(" ", "");
            IA = line.Substring(21, 8).Replace(" ", "");
            DIA = line.Substring(29, 2).Replace(" ", "");
            HF = line.Substring(31, 8).Replace(" ", "");
            DHF = line.Substring(39, 2).Replace(" ", "");
            FLAG = line.Substring(76, 1).Replace(" ", "");
            Q = line.Substring(79, 1).Replace(" ", "");
        }

        public string E;
        public string DE;
        public string IA;
        public string DIA;
        public string HF;
        public string DHF;
        public string FLAG;
        public string Q;
    }
}
