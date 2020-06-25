using System;
using Examine;
using Our.Umbraco.ExamineConfig.Composing;
using Our.Umbraco.ExamineConfig.Helpers;
using Umbraco.Examine;
using UmbracoExamine = Umbraco.Examine;
using UmbracoIndexes = Umbraco.Core.Constants.UmbracoIndexes;

namespace Our.Umbraco.ExamineConfig.Startup
{
    internal class CoreIndexConfig : UmbracoExamine.IUmbracoIndexConfig
    {
        private readonly IndexCollection _indexCollection;
        private readonly ValueSetHelper _valueSetHelper;

        public CoreIndexConfig(IndexCollection indexCollection, ValueSetHelper valueSetHelper)
        {
            _indexCollection = indexCollection;
            _valueSetHelper = valueSetHelper;
        }

        public IContentValueSetValidator GetContentValueSetValidator()
        {
            var config = _indexCollection[UmbracoIndexes.InternalIndexName] as IUmbracoIndexConfig;

            if (config != null)
            {
                throw new Exception("Cannot modify internal index");
            }

            return _valueSetHelper.ContentValidator(config);
        }

        public IContentValueSetValidator GetPublishedContentValueSetValidator()
        {
            var config = _indexCollection[UmbracoIndexes.ExternalIndexName] as IUmbracoIndexConfig;

            return _valueSetHelper.PublishedContentValidator(config);
        }

        public IValueSetValidator GetMemberValueSetValidator()
        {
            var config = _indexCollection[UmbracoIndexes.MembersIndexName] as IUmbracoIndexConfig;

            return _valueSetHelper.MemberValidator(config);
        }
    }
}