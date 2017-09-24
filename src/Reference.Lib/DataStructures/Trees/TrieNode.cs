using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reference.Lib.DataStructures.Trees
{

    public class TrieNode
    {
        internal Dictionary<char, TrieNode> children;

        public char Key { get; internal set; }

        public bool IsWord { get; internal set; }

        public ReadOnlyDictionary<char, TrieNode> Children => new ReadOnlyDictionary<char, TrieNode>(children);

        public TrieNode(char key, bool isWord)
        {
            Key = key;
            IsWord = isWord;
            children = new Dictionary<char, TrieNode>();
        }

    }
}