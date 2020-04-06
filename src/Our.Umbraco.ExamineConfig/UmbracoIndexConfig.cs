using Examine;
using Our.Umbraco.ExamineConfig.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Examine;
using Umbraco.Web.Search;
using UmbracoIndexes = Umbraco.Core.Constants.UmbracoIndexes;

namespace Our.Umbraco.ExamineConfig
{
	public class UmbracoIndexConfig : IUmbracoIndexConfig
	{
		private readonly IPublicAccessService _publicAccessService;
		public UmbracoIndexConfig(IPublicAccessService publicAccessService)
		{
			_publicAccessService = publicAccessService;
		}
		IContentValueSetValidator IUmbracoIndexConfig.GetContentValueSetValidator()
		{
			var config = new ExamineIndexConfig(UmbracoIndexes.InternalIndexName);

			return new ContentValueSetValidator(false, config.SupportProtectedContent, _publicAccessService, config.ParentId, config.IncludeItemTypes, config.ExcludeItemTypes);
		}

		IValueSetValidator IUmbracoIndexConfig.GetMemberValueSetValidator()
		{
			var config = new ExamineIndexConfig(UmbracoIndexes.MembersIndexName);

			return new MemberValueSetValidator(config.IncludeItemTypes, config.ExcludeItemTypes);
		}

		IContentValueSetValidator IUmbracoIndexConfig.GetPublishedContentValueSetValidator()
		{
			var config = new ExamineIndexConfig(UmbracoIndexes.ExternalIndexName);
			return new ContentValueSetValidator(true, config.SupportProtectedContent, _publicAccessService, config.ParentId, config.IncludeItemTypes, config.ExcludeItemTypes);
		}
	}
}