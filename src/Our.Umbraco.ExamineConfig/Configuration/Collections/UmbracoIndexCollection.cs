using System.Configuration;
using Examine.Config.Configuration.Collections;
using Our.Umbraco.ExamineConfig.Configuration.Sections;

namespace Our.Umbraco.ExamineConfig.Configuration.Collections
{
    [ConfigurationCollection(typeof(UmbracoIndexSection), AddItemName = "index")]
    public class UmbracoIndexCollection : BaseCollection<UmbracoIndexSection>
    {
        protected override object GetElementKey(UmbracoIndexSection element) => element.Name;
    }
}