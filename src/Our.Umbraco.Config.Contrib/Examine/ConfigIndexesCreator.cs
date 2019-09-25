using Examine;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Examine;
using Umbraco.Web.Search;
using UmbracoIndexes = Umbraco.Core.Constants.UmbracoIndexes;

namespace Our.Umbraco.Config.Contrib.Examine
{
    public class ConfigIndexesCreator : UmbracoIndexesCreator
    {
        private readonly IPublicAccessService _publicAccessService;

        public ConfigIndexesCreator(IProfilingLogger profilingLogger, ILocalizationService languageService, IPublicAccessService publicAccessService, IMemberService memberService)
            : base(profilingLogger, languageService, publicAccessService, memberService)
        {
            _publicAccessService = publicAccessService;
        }

        public override IContentValueSetValidator GetContentValueSetValidator()
        {
            var config = new ExamineIndexConfig(UmbracoIndexes.InternalIndexName);

            return new ContentValueSetValidator(false, config.SupportProtectedContent, _publicAccessService, config.ParentId, config.IncludeItemTypes, config.ExcludeItemTypes);
        }

        public override IValueSetValidator GetMemberValueSetValidator()
        {
            return base.GetMemberValueSetValidator();
        }

        public override IContentValueSetValidator GetPublishedContentValueSetValidator()
        {
            var config = new ExamineIndexConfig(UmbracoIndexes.ExternalIndexName);

            return new ContentValueSetValidator(true, config.SupportProtectedContent, _publicAccessService, config.ParentId, config.IncludeItemTypes, config.ExcludeItemTypes);
        }
    }
}