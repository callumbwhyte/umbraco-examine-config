using System.Configuration;
using Examine.Config.Configuration.Collections;
using Our.Umbraco.ExamineConfig.Configuration.Elements;

namespace Our.Umbraco.ExamineConfig.Configuration.Collections
{
    [ConfigurationCollection(typeof(ContentTypeElement))]
    public class ContentTypeCollection : BaseCollection<ContentTypeElement>
    {
        protected override object GetElementKey(ContentTypeElement element) => element.Name;
    }
}