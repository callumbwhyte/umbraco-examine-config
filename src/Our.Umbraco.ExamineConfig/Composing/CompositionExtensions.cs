using Umbraco.Core.Composing;

namespace Our.Umbraco.ExamineConfig.Composing
{
    public static class CompositionExtensions
    {
        public static IndexCollectionBuilder Indexes(this Composition composition)
        {
            return composition.WithCollectionBuilder<IndexCollectionBuilder>();
        }

        public static SearcherCollectionBuilder Searchers(this Composition composition)
        {
            return composition.WithCollectionBuilder<SearcherCollectionBuilder>();
        }
    }
}