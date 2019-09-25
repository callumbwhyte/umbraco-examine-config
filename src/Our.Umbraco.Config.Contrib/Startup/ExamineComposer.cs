using Our.Umbraco.Config.Contrib.Examine;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web.Search;

namespace Our.Umbraco.Config.Contrib.Startup
{
    [ComposeAfter(typeof(ExamineComposer))]
    public class ExamineConfigComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.RegisterUnique<IUmbracoIndexesCreator, ConfigIndexesCreator>();
        }
    }
}