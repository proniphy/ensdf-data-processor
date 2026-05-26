using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class NormalizationRecord : Record
    {
        public NormalizationRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            NR = line.Substring(9, 10).Replace(" ", "");
            DNR = line.Substring(19, 2).Replace(" ", "");
            NT = line.Substring(21, 8).Replace(" ", "");
            DNT = line.Substring(29, 2).Replace(" ", "");
            BR = line.Substring(31, 8).Replace(" ", "");
            DBR = line.Substring(39, 2).Replace(" ", "");
            NB = line.Substring(41, 8).Replace(" ", "");
            DNB = line.Substring(49, 6).Replace(" ", "");
            NP = line.Substring(55, 7).Replace(" ", "");
            DNP = line.Substring(62, 2).Replace(" ", "");
        }

        public string NR;
        public string DNR;
        public string NT;
        public string DNT;
        public string BR;
        public string DBR;
        public string NB;
        public string DNB;
        public string NP;
        public string DNP;
    }
}
