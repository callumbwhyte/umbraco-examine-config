using System.Configuration;

namespace Our.Umbraco.ExamineConfig.Configuration.Elements
{
    public class ContentTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }
    }
}