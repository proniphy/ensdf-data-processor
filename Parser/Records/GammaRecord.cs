using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class GammaRecord : Record
    {
        public GammaRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            E = line.Substring(9, 10).Replace(" ", "");
            DE = line.Substring(19, 2).Replace(" ", "");
            RI = line.Substring(21, 8).Replace(" ", "");
            DRI = line.Substring(29, 2).Replace(" ", "");
            M = line.Substring(31, 10).Replace(" ", "");
            MR = line.Substring(41, 8).Replace(" ", "");
            DMR = line.Substring(49, 6).Replace(" ", "");
            CC = line.Substring(55, 7).Replace(" ", "");
            DCC = line.Substring(62, 2).Replace(" ", "");
            TI = line.Substring(64, 10).Replace(" ", "");
            DTI = line.Substring(74, 2).Replace(" ", "");
            FLAG = line.Substring(76, 1).Replace(" ", "");
            COIN = line.Substring(77, 1).Replace(" ", "");
            Q = line.Substring(79, 1).Replace(" ", "");
        }

        public string E;
        public string DE;
        public string RI;
        public string DRI;
        public string M;
        public string MR;
        public string DMR;
        public string CC;
        public string DCC;
        public string TI;
        public string DTI;
        public string FLAG;
        public string COIN;
        public string Q;
    }
}
