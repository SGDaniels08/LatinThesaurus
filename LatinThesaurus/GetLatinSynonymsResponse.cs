using System.Collections.Generic;

namespace LatinThesaurus
{
    public class GetLatinSynonymsResponse
    {
        public int Count { get; set; }
        // next
        // previous

        /// <summary>
        /// Found at /api/lemmas/{lemma}
        /// </summary>
        public List<Synset> Results { get; set; }
    }
}