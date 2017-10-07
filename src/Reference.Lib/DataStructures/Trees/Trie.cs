using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Trees
{
    public class Trie
    {
        public Trie()
        {
            Root = new TrieNode(default(char), false);
        }

        public TrieNode Root { get; }

        public int WordCount { get; private set; }

        public void AddWord(string word)
        {
            AddWord(word, 0, Root);
        }

        public void AddWords(params string[] words)
        {
            foreach (var word in words)
                AddWord(word);
        }


        private void AddWord(string word, int position, TrieNode current)
        {
            var key = word[position];

            if (current.ChildNodes.ContainsKey(key))
            {
                // we found a matching char in children
                // at the end of the word
                if (position == word.Length - 1)
                {
                    // complete word
                    if (!current.ChildNodes[key].IsWord)
                    {
                        current.ChildNodes[key].IsWord = true;
                        ++WordCount;
                    }
                }
                else
                {
                    AddWord(word, ++position, current.ChildNodes[key]);
                }
            }
            else
            {
                // did not find key in child collection, add it
                current.ChildNodes.Add(
                    key,
                    new TrieNode(
                        key,
                        position == word.Length - 1)
                );


                if (position < word.Length - 1)
                    AddWord(word, ++position, current.ChildNodes[key]);
                else
                    ++WordCount;
            }
        }

        public IEnumerable<string> GetWords()
        {
            var words = new List<string>(WordCount);
            foreach (var node in Root.ChildNodes)
                GetWords(node.Value, string.Empty, words);
            return words;
        }

        public void GetWords(TrieNode current, string prefix, IList<string> words)
        {
            // root
            prefix += current.Key;

            if (current.IsWord)
                words.Add(prefix);

            foreach (var child in current.ChildNodes)
                GetWords(child.Value, prefix, words);
        }
    }
}