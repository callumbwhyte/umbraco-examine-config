using Examine.Config;

namespace Our.Umbraco.ExamineConfig.Composing
{
    public class SearcherCollectionBuilder : KeyValueCollectionBuilder<SearcherCollectionBuilder, SearcherCollection, ISearcherConfig>
    {
        protected override SearcherCollectionBuilder This => this;

        public override string GetKey(ISearcherConfig item) => item.Name;
    }
}