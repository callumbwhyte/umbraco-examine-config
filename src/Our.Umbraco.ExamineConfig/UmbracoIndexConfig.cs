using System;
using System.Collections.Generic;
using Examine.Config;

namespace Our.Umbraco.ExamineConfig
{
    public abstract class UmbracoIndexConfig : IUmbracoIndexConfig
    {
        public abstract string Name { get; }

        public virtual IEnumerable<IIndexField> IncludeFields { get; }

        public virtual IEnumerable<IIndexField> ExcludeFields { get; }

        public virtual Type Type { get; }

        public virtual string Path { get; }

        public virtual Type Analyzer { get; }

        public virtual bool IncludePublished { get; } = true;

        public virtual bool IncludeProtected { get; } = false;

        public virtual string[] IncludeTypes { get; }

        public virtual string[] ExcludeTypes { get; }
    }
}