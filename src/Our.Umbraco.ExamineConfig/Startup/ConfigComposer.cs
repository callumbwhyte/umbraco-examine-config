using System;
using System.Configuration;
using Examine.Config;
using Our.Umbraco.ExamineConfig.Composing;
using Umbraco.Core.Composing;
using Umbraco.Web.Search;

namespace Our.Umbraco.ExamineConfig.Startup
{
    [ComposeAfter(typeof(ExamineComposer))]
    public class ConfigComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            RegisterConfig(composition);
        }

        private void RegisterConfig(Composition composition)
        {
            var examineSection = ConfigurationManager.GetSection("examine");

            if (!(examineSection is IExamineConfig examineConfig))
            {
                throw new Exception("Failed to load Examine config");
            }

            foreach (var index in examineConfig.Indexes)
            {
                composition.Indexes().Add(index);
            }

            foreach (var searcher in examineConfig.Searchers)
            {
                composition.Searchers().Add(searcher);
            }
        }
    }
}