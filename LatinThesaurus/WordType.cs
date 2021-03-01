using System.Collections.Generic;

namespace LatinThesaurus
{
    public class WordType
    {
        public List<Word> Literal { get; set; }
        public List<Word> Metonymic { get; set; }
        public List<Word> Metaphoric { get; set; }
    }
}