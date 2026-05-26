using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSDF_Parser
{
    public class QValueRecord : Record
    {
        public QValueRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            Q = line.Substring(9, 10).Replace(" ", "");
            DQ = line.Substring(19, 2).Replace(" ", "");
            SN = line.Substring(21, 8).Replace(" ", "");
            DSN = line.Substring(29, 2).Replace(" ", "");
            SP = line.Substring(31, 8).Replace(" ", "");
            DSP = line.Substring(39, 2).Replace(" ", "");
            QA = line.Substring(41, 8).Replace(" ", "");
            DQA = line.Substring(49, 6).Replace(" ", "");
            QREF = line.Substring(55, 25).Replace(" ", "");
        }

        public string Q;
        public string DQ;
        public string SN;
        public string DSN;
        public string SP;
        public string DSP;
        public string QA;
        public string DQA;
        public string QREF;
    }
}
