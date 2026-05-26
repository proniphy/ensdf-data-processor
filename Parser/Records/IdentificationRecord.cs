using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class IdentificationRecord : Record
    {
        public IdentificationRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            DSID = line.Substring(9, 30).Replace(" ", "");
            DSREF = line.Substring(39, 26).Replace(" ", "");
            PUB = line.Substring(65, 9).Replace(" ", "");
            DATE = line.Substring(74, 6).Replace(" ", "");
        }

        public string DSID;
        public string DSREF;
        public string PUB;
        public string DATE;
    }
}
