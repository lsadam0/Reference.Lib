using Xunit;

using Reference.Lib.DataStructures.Trees;

namespace Reference.Lib.Tests.DataStructures.Trees
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