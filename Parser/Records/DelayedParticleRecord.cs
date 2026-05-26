using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSDF_Parser
{
    public class DelayedParticleRecord : Record
    {
        public DelayedParticleRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            Particle = line.Substring(8, 1).Replace(" ", "");

            E = line.Substring(9, 10).Replace(" ", "");
            DE = line.Substring(19, 2).Replace(" ", "");
            IP = line.Substring(21, 8).Replace(" ", "");
            DIP = line.Substring(29, 2).Replace(" ", "");
            EI = line.Substring(31, 8).Replace(" ", "");
            T = line.Substring(39, 10).Replace(" ", "");
            DT = line.Substring(49, 6).Replace(" ", "");
            L = line.Substring(55, 9).Replace(" ", "");
            FLAG = line.Substring(76, 1).Replace(" ", "");
            COIN = line.Substring(77, 1).Replace(" ", "");
            Q = line.Substring(79, 1).Replace(" ", "");
        }

        public string Particle;

        public string E;
        public string DE;
        public string IP;
        public string DIP;
        public string EI;
        public string T;
        public string DT;
        public string L;
        public string FLAG;
        public string COIN;
        public string Q;
    }
}
