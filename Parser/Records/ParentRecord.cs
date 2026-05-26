using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class ParentRecord : Record
    {
        public ParentRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            E = line.Substring(9, 10).Replace(" ", "");
            DE = line.Substring(19, 2).Replace(" ", "");
            J = line.Substring(21, 18).Replace(" ", "");
            T = line.Substring(39, 10).Replace(" ", "");
            DT = line.Substring(49, 6).Replace(" ", "");
            QP = line.Substring(64, 10).Replace(" ", "");
            DQP = line.Substring(74, 2).Replace(" ", "");
            ION = line.Substring(76, 4).Replace(" ", "");
        }

        public string E;
        public string DE;
        public string J;
        public string T;
        public string DT;
        public string QP;
        public string DQP;
        public string ION;
    }
}
