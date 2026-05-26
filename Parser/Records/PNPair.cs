using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSDF_Parser.MetaData;

namespace ENSDF_Parser.Records
{
    public class PNPair
    {
        public ParentRecord Parent;
        public NormalizationRecord Normalization;
    }
}
