using Examine;
using Our.Umbraco.ExamineConfig.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Examine;
using Umbraco.Web.Search;
using UmbracoIndexes = Umbraco.Core.Constants.UmbracoIndexes;

namespace Our.Umbraco.ExamineConfig
{
    public class UmbracoIndexCreator : UmbracoIndexesCreator
    {
        private readonly IPublicAccessService _publicAccessService;

        public UmbracoIndexCreator(IProfilingLogger profilingLogger, ILocalizationService languageService, IPublicAccessService publicAccessService, IMemberService memberService,IUmbracoIndexConfig indexConfig)
            : base(profilingLogger, languageService, publicAccessService, memberService,indexConfig)
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
            var config = new ExamineIndexConfig(UmbracoIndexes.MembersIndexName);

            return new MemberValueSetValidator(config.IncludeItemTypes, config.ExcludeItemTypes);
        }

        public override IContentValueSetValidator GetPublishedContentValueSetValidator()
        {
            var config = new ExamineIndexConfig(UmbracoIndexes.ExternalIndexName);

            return new ContentValueSetValidator(true, config.SupportProtectedContent, _publicAccessService, config.ParentId, config.IncludeItemTypes, config.ExcludeItemTypes);
        }
    }
}