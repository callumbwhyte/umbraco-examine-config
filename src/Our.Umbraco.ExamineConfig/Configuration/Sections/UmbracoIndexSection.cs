using System.Configuration;
using System.Linq;
using Examine.Config.Configuration.Sections;
using Our.Umbraco.ExamineConfig.Configuration.Collections;

namespace Our.Umbraco.ExamineConfig.Configuration.Sections
{
    public class UmbracoIndexSection : IndexSection, IUmbracoIndexConfig
    {
        [ConfigurationProperty("includePublished", IsRequired = false)]
        public bool IncludePublished
        {
            get
            {
                return (bool)base["includePublished"];
            }
        }

        [ConfigurationProperty("includeProtected", IsRequired = false)]
        public bool IncludeProtected
        {
            get
            {
                return (bool)base["includeProtected"];
            }
        }

        [ConfigurationProperty("includeTypes", IsRequired = false)]
        public ContentTypeCollection IncludeTypes
        {
            get
            {
                return (ContentTypeCollection)base["includeTypes"];
            }
        }

        [ConfigurationProperty("excludeTypes", IsRequired = false)]
        public ContentTypeCollection ExcludeTypes
        {
            get
            {
                return (ContentTypeCollection)base["excludeTypes"];
            }
        }

        #region Interface members

        string[] IUmbracoIndexConfig.IncludeTypes => IncludeTypes.Select(x => x.Name).ToArray();

        string[] IUmbracoIndexConfig.ExcludeTypes => ExcludeTypes.Select(x => x.Name).ToArray();

        #endregion
    }
}