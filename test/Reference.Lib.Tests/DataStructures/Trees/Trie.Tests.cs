using Reference.Lib.DataStructures.Trees;
using Xunit;

namespace Reference.Lib.Test.DataStructures.Trees
{
    public class TrieTests
    {
        [Fact]
        public void Trie_SimpleCase()
        {
            var data = new string[5]
            {
                "Week",
                "WeekDay",
                "Weekend",
                "weekday",
                "weekday"
            };

            var trie = new Trie();

            trie.AddWords(data);

            Assert.Equal(4, trie.WordCount);

            var all = trie.GetWords();
        }
    }
}