using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Reference.Lib.DataStructures.Trees
{

    public class Trie 
    {
        public TrieNode Root { get; private set; }

        public int WordCount { get; private set; }

        public Trie()
        {
            Root = new TrieNode(default(char), false);
        }

        public void AddWord(string word) => AddWord(word, 0, Root);

        public void AddWords(params string[] words)
        {
            foreach (var word in words)
                AddWord(word);
        }


        private void AddWord(string word, int position, TrieNode current)
        {
            char key = word[position];

            if (current.children.ContainsKey(key))
            {
                // we found a matching char in children
                // at the end of the word
                if (position == word.Length - 1)
                {
                    // complete word
                    if (!current.children[key].IsWord)
                    {
                        current.children[key].IsWord = true;
                        ++WordCount;
                    }
                    return;
                }
                else
                    AddWord(word, ++position, current.children[key]);
                
            }
            else
            {
                // did not find key in child collection, add it
                current.children.Add(
                    key,
                    new TrieNode(
                        key,
                        position == word.Length - 1)
                    );
             

                if (position < (word.Length - 1))
                    AddWord(word, ++position, current.children[key]);
                else
                    ++WordCount;
            }
        }

        public IEnumerable<string> GetWords()
        {
            var words = new List<string>(WordCount);
            foreach (var node in Root.children)
            {
                GetWords(node.Value, string.Empty, words);
            }
            return words;
        }

        public void GetWords(TrieNode current, string prefix, IList<string> words)
        {
            // root
            prefix += current.Key;       

            if (current.IsWord)
                words.Add(prefix);

            foreach (var child in current.children)
                GetWords(child.Value, prefix, words);
        }
      
    }

}