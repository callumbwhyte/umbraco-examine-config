using System;
using System.Configuration;
using Examine.Config;
using Our.Umbraco.ExamineConfig.Composing;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web.Search;
using UmbracoExamine = Umbraco.Examine;

namespace Our.Umbraco.ExamineConfig.Startup
{
    [ComposeAfter(typeof(ExamineComposer))]
    public class ConfigComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            RegisterConfig(composition);

            composition.RegisterUnique<UmbracoExamine.IUmbracoIndexConfig, CoreIndexConfig>();
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