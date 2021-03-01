using System.Collections.Generic;

namespace LatinThesaurus
{
    public class Word
    {
        public string Lemma { get; set; }
        public string POS { get; set; }
        public string Morpho { get; set; }
        public string Prosody { get; set; }
        // PhonologicalTranscription (complex object)
        public string PrincipalParts { get; set; }
        public SynsetType Synsets { get; set; }
        // irregular forms
        // alternative forms
        // validated
    }
}