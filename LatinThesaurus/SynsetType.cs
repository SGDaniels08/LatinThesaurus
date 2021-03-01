using System.Collections.Generic;

namespace LatinThesaurus
{
    public class SynsetType
    {
        public List<Synset> Literal { get; set; }
        public List<Synset> Metonymic { get; set; }
        public List<Synset> Metaphoric { get; set; }
    }
}