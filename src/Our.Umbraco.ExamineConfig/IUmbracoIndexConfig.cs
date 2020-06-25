using Examine.Config;

namespace Our.Umbraco.ExamineConfig
{
    public interface IUmbracoIndexConfig : IIndexConfig
    {
        bool IncludePublished { get; }
        bool IncludeProtected { get; }
        string[] IncludeTypes { get; }
        string[] ExcludeTypes { get; }
    }
}