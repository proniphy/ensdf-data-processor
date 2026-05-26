using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class CrossReferenceRecord : Record
    {
        public CrossReferenceRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            DSSYM = line.Substring(8, 1).Replace(" ", "");
            DSID = line.Substring(9, 30).Replace(" ", "");
        }

        public string DSSYM;
        public string DSID;
    }
}
