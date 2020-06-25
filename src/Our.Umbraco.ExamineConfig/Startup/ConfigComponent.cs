using System.Linq;
using Examine.Config.Helpers;
using Our.Umbraco.ExamineConfig.Composing;
using Umbraco.Core.Composing;
using UmbracoIndexes = Umbraco.Core.Constants.UmbracoIndexes;

namespace Our.Umbraco.ExamineConfig.Startup
{
    public class ConfigComponent : IComponent
    {
        private readonly IndexCollection _indexCollection;
        private readonly SearcherCollection _searcherCollection;
        private readonly IExamineHelper _examineHelper;

        public ConfigComponent(IndexCollection indexCollection, SearcherCollection searcherCollection, IExamineHelper examineHelper)
        {
            _indexCollection = indexCollection;
            _searcherCollection = searcherCollection;
            _examineHelper = examineHelper;
        }

        public void Initialize()
        {
            var coreIndexes = new[]
            {
                UmbracoIndexes.ExternalIndexName,
                UmbracoIndexes.InternalIndexName,
                UmbracoIndexes.MembersIndexName
            };

            var indexes = _indexCollection.Where(x => coreIndexes.Contains(x.Name) == false);

            _examineHelper.ConfigureIndexes(indexes);

            _examineHelper.ConfigureSearchers(_searcherCollection);
        }

        public void Terminate()
        {

        }
    }
}