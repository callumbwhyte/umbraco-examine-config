using Examine.Config;
using Examine.Config.Helpers;
using Our.Umbraco.ExamineConfig.Composing;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.ExamineConfig.Startup
{
    public class ExamineConfigComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IndexCollection>();

            composition.Register<SearcherCollection>();

            composition.RegisterUnique<IExamineHelper, ExamineHelper>();
        }
    }
}