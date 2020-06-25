using Examine.Config;

namespace Our.Umbraco.ExamineConfig.Composing
{
    public class IndexCollectionBuilder : KeyValueCollectionBuilder<IndexCollectionBuilder, IndexCollection, IIndexConfig>
    {
        protected override IndexCollectionBuilder This => this;

        public override string GetKey(IIndexConfig item) => item.Name;
    }
}