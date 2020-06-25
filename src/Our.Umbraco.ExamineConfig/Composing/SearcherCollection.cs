using System.Collections.Generic;
using System.Linq;
using Examine.Config;
using Umbraco.Core.Composing;

namespace Our.Umbraco.ExamineConfig.Composing
{
    public class SearcherCollection : BuilderCollectionBase<ISearcherConfig>
    {
        private readonly IEnumerable<ISearcherConfig> _items;

        public SearcherCollection(IEnumerable<ISearcherConfig> items)
            : base(items)
        {
            _items = items;
        }

        public ISearcherConfig this[string name] => _items.FirstOrDefault(x => x.Name == name);
    }
}