using System.Collections.Generic;

namespace LatinThesaurus
{
    public class SearchByLemmaResponse
    {
        public int Count { get; set; }
        // next
        // previous
        
        /// <summary>
        /// Found at /api/lemmas/{lemma}
        /// </summary>
        public List<Word> Results { get; set; }
    }
}