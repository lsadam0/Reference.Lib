using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reference.Lib.DataStructures.Collections;

namespace Reference.Lib.DataStructures.Trees
{
    public class TrieNode
    {
        internal Dictionary<char, TrieNode> ChildNodes;

        public TrieNode(char key, bool isWord)
        {
            Key = key;
            IsWord = isWord;
            ChildNodes = new Dictionary<char, TrieNode>();
        }

        public char Key { get; internal set; }

        public bool IsWord { get; internal set; }

        public ReadOnlyDictionary<char, TrieNode> Children => new ReadOnlyDictionary<char, TrieNode>(ChildNodes);
    }
}