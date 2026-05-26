using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class HistoryRecord : Record
    {
        public HistoryRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            HTEXT = line.Substring(9, 71).Replace(" ", "");
        }

        public string HTEXT;
    }
}
