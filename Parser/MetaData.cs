using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSDF_Parser
{
    public struct Identifier
    {
        public byte Isotrope;
        public string Name;
    }

    public struct RecordType
    {
        public char C1;
        public char C2;
        public char C3;
        public char C4;
    }
}
