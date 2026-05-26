using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSDF_Parser
{
    public class CommentRecord : Record
    {
        public CommentRecord(Identifier id, RecordType rtype, string line) : base(id, rtype)
        {
            CTEXT = line.Substring(9, 71);
        }

        public string CTEXT;
    }
}
