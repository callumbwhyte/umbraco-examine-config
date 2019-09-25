using System;
using System.Configuration;

namespace Our.Umbraco.ExamineConfig.Helpers
{
    internal static class ConfigHelper
    {
        private const string ExaminePrefix = "Umbraco.Examine";

        public static int? ParentId(string indexName)
        {
            int.TryParse(ConfigurationManager.AppSettings[ExaminePrefix + "." + indexName + ".ParentId"], out int parentId);

            if (parentId > 0)
            {
                return parentId;
            }

            return null;
        }

        public static string[] IncludeItemTypes(string indexName)
        {
            var includeItemTypes = ConfigurationManager.AppSettings[ExaminePrefix + "." + indexName + ".IncludeItemTypes"];

            if (string.IsNullOrWhiteSpace(includeItemTypes) == false)
            {
                return includeItemTypes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return null;
        }

        public static string[] ExcludeItemTypes(string indexName)
        {
            var excludeItemTypes = ConfigurationManager.AppSettings[ExaminePrefix + "." + indexName + ".ExcludeItemTypes"];

            if (string.IsNullOrWhiteSpace(excludeItemTypes) == false)
            {
                return excludeItemTypes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return null;
        }

        public static bool SupportProtectedContent(string indexName)
        {
            bool.TryParse(ConfigurationManager.AppSettings[ExaminePrefix + "." + indexName + ".SupportProtectedContent"], out bool supportProtectedContent);

            return supportProtectedContent;
        }
    }
}