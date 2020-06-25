using System.Linq;
using Examine;
using Umbraco.Core.Services;
using Umbraco.Examine;

namespace Our.Umbraco.ExamineConfig.Helpers
{
    internal class ValueSetHelper
    {
        private readonly IPublicAccessService _publicAccessService;

        public ValueSetHelper(IPublicAccessService publicAccessService)
        {
            _publicAccessService = publicAccessService;
        }

        public IContentValueSetValidator ContentValidator(IUmbracoIndexConfig config)
        {
            return new ContentValueSetValidator(false, true, _publicAccessService, null, config?.IncludeTypes, config?.ExcludeTypes);
        }

        public IContentValueSetValidator PublishedContentValidator(IUmbracoIndexConfig config)
        {
            var includePublished = config?.IncludePublished ?? true;

            var includeProtected = config?.IncludeProtected ?? false;

            return new ContentValueSetValidator(includePublished, includeProtected, _publicAccessService, null, config?.IncludeTypes, config?.ExcludeTypes);
        }

        public IValueSetValidator MemberValidator(IUmbracoIndexConfig config)
        {
            var includeFields = config?.IncludeFields?.Select(x => x.Name);

            var excludeFields = config?.IncludeFields?.Select(x => x.Name);

            return new MemberValueSetValidator(config?.IncludeTypes, config?.ExcludeTypes, includeFields, excludeFields);
        }
    }
}