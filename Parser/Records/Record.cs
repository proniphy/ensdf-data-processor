using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class Record
    {
        public Record(Identifier id, RecordType rtype)
        {
            Id = id;
            RType = rtype;
            Comments = new List<CommentRecord>();
        }

        public Identifier Id;
        public RecordType RType;
        public List<CommentRecord> Comments;
    }
}
