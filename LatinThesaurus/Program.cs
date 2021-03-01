﻿using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace LatinThesaurus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Base URL of Web API
            var client1 = new RestClient("https://latinwordnet.exeter.ac.uk/api/");
            var client2 = new RestClient("https://latinwordnet.exeter.ac.uk/api/");


            string lemma;

            Console.WriteLine("Enter the lemma and find other words with a similar meaning:");
            Console.Write(">> ");
            lemma = Console.ReadLine();

            // Check word; if not a lemma, find all possibilities and ask which word the user means

            // If word is a lemma, retrieve it
            // HTTP Request object
            RestRequest searchByLemmaRequest = new RestRequest($"lemmas/{lemma}/synsets", Method.GET);
            // HTTP Response object
            IRestResponse<SearchByLemmaResponse> sblr = client1.Execute<SearchByLemmaResponse>(searchByLemmaRequest);

            /* Disambiguation */

            // Once correct word is chosen, list synsets ; user chooses desired synset
            Word toThesaurize = sblr.Data.Results[0];
            SynsetType literalMetonymicMetaphoric = toThesaurize.Synsets;
            int count = 0;

            Console.WriteLine("Please enter a number to choose your preferred synset:\n\n");
            foreach (Synset synset in literalMetonymicMetaphoric.Literal)
            {
                count++;

                Console.WriteLine($"{count}: {synset.Gloss}\n");
            }
            Console.Write("\n>> ");

            string synsetChoiceString = Console.ReadLine();
            int synsetChoiceIndex = Int32.Parse(synsetChoiceString) - 1;
            Synset selectedSynset = literalMetonymicMetaphoric.Literal[synsetChoiceIndex];

            /* Return all synonyms (words in that synset) */
            RestRequest getLatinSynonymsRequest = new RestRequest($"synsets/*/{selectedSynset.Offset}/lemmas", Method.GET);
            IRestResponse<GetLatinSynonymsResponse> glsr = client2.Execute<GetLatinSynonymsResponse>(getLatinSynonymsRequest);

            List<Word> synonyms = glsr.Data.Results[0].Lemmas.Literal;

            Console.WriteLine("\n\nHere's all your synonyms:\n\n");

            foreach (Word word in synonyms)
            {
                Console.Write(word.Lemma + " -- ");
            }
        }
    }
}
