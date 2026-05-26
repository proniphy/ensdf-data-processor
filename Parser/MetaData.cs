using ENSDF_Parser.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSDF_Parser.MetaData
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

    public class Header
    {
        public List<IdentificationRecord> IdentificationRecords = new();
        public List<HistoryRecord> HistoryRecords = new();
        public List<CrossReferenceRecord> CrossReferenceRecords = new();
        public List<QValueRecord> QValueRecords = new();
        public List<PNPair> PN_Pairs = new();
        public List<CommentRecord> CommentRecords = new();
    }

    public class RadiationData
    {
        public List<GammaRecord> GammaRecords = new();
        public List<BetaRecord> BettaRecords = new();
        public List<ECRecord> ECRecords = new();
        public List<AlphaRecord> AlphaRecords = new();
        public List<DelayedParticleRecord> DelayedParticleRecords = new();
    }

    public class Level
    {
        public LevelRecord LevelRecord;
        public RadiationData Data = new();
    }
}
