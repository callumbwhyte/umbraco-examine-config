using System.Collections.Generic;
using System.Linq;
using Examine.Config;
using Umbraco.Core.Composing;

namespace Our.Umbraco.ExamineConfig.Composing
{
    public class IndexCollection : BuilderCollectionBase<IIndexConfig>
    {
        private readonly IEnumerable<IIndexConfig> _items;

        public IndexCollection(IEnumerable<IIndexConfig> items)
            : base(items)
        {
            _items = items;
        }

        public IIndexConfig this[string name] => _items.FirstOrDefault(x => x.Name == name);
    }
}