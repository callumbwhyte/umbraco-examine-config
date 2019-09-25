using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web.Search;

namespace Our.Umbraco.ExamineConfig.Startup
{
    [ComposeAfter(typeof(ExamineComposer))]
    public class ExamineConfigComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.RegisterUnique<IUmbracoIndexesCreator, UmbracoIndexCreator>();
        }
    }
}