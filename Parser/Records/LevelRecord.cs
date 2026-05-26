using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSDF_Parser
{
    public class LevelRecord : Record
    {
        public LevelRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            E = line.Substring(9, 10).Replace(" ", "");
            DE = line.Substring(19, 2).Replace(" ", "");
            J = line.Substring(21, 18).Replace(" ", "");
            T = line.Substring(39, 10).Replace(" ", "");
            DT = line.Substring(49, 6).Replace(" ", "");
            L = line.Substring(55, 9).Replace(" ", "");
            S = line.Substring(64, 10).Replace(" ", "");
            DS = line.Substring(74, 2).Replace(" ", "");
            FLAG = line.Substring(76, 1).Replace(" ", "");
            MS = line.Substring(77, 2).Replace(" ", "");
            Q = line.Substring(79, 1).Replace(" ", "");
        }

        public string E;
        public string DE;
        public string J;
        public string T;
        public string DT;
        public string L;
        public string S;
        public string DS;
        public string FLAG;
        public string MS;
        public string Q;
    }
}
