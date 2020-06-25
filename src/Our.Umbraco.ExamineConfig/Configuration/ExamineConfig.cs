using System.Collections.Generic;
using System.Configuration;
using Examine.Config;
using Examine.Config.Configuration.Collections;
using Our.Umbraco.ExamineConfig.Configuration.Collections;

namespace Our.Umbraco.ExamineConfig.Configuration
{
    public class ExamineConfig : ConfigurationSection, IExamineConfig
    {
        [ConfigurationProperty("indexes", IsRequired = true)]
        public UmbracoIndexCollection Indexes
        {
            get
            {
                return (UmbracoIndexCollection)base["indexes"];
            }
        }

        [ConfigurationProperty("searchers", IsRequired = true)]
        public SearcherCollection Searchers
        {
            get
            {
                return (SearcherCollection)base["searchers"];
            }
        }

        #region Interface members

        IEnumerable<IIndexConfig> IExamineConfig.Indexes => Indexes;

        IEnumerable<ISearcherConfig> IExamineConfig.Searchers => Searchers;

        #endregion
    }
}