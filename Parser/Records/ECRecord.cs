using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class ECRecord : Record
    {
        public ECRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            E = line.Substring(9, 10).Replace(" ", "");
            DE = line.Substring(19, 2).Replace(" ", "");
            IB = line.Substring(21, 8).Replace(" ", "");
            DIB = line.Substring(29, 2).Replace(" ", "");
            IE = line.Substring(31, 8).Replace(" ", "");
            DIE = line.Substring(39, 2).Replace(" ", "");
            LOGFT = line.Substring(41, 8).Replace(" ", "");
            DFT = line.Substring(49, 6).Replace(" ", "");
            TI = line.Substring(64, 10).Replace(" ", "");
            DTI = line.Substring(74, 2).Replace(" ", "");
            FLAG = line.Substring(76, 1).Replace(" ", "");
            UN = line.Substring(77, 2).Replace(" ", "");
            Q = line.Substring(79, 1).Replace(" ", "");
        }

        public string E;
        public string DE;
        public string IB;
        public string DIB;
        public string IE;
        public string DIE;
        public string LOGFT;
        public string DFT;
        public string TI;
        public string DTI;
        public string FLAG;
        public string UN;
        public string Q;
    }
}
