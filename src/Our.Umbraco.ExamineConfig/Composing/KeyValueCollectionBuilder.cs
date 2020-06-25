using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.ExamineConfig.Composing
{
    public abstract class KeyValueCollectionBuilder<TBuilder, TCollection, TItem> : ICollectionBuilder<TCollection, TItem>
        where TBuilder : class, ICollectionBuilder<TCollection, TItem>
        where TCollection : class, IBuilderCollection<TItem>
        where TItem : class
    {
        private IDictionary<string, TItem> _collection = new Dictionary<string, TItem>();

        protected abstract TBuilder This { get; }

        protected virtual bool TryGetItem(string key, out TItem value)
        {
            if (_collection.TryGetValue(key, out TItem item) == true)
            {
                value = item;

                return true;
            }

            value = default(TItem);

            return false;
        }

        protected virtual IDictionary<string, TItem> GetItems() => _collection;

        public virtual TBuilder Add(TItem item)
        {
            var key = GetKey(item);

            _collection[key] = item;

            return This;
        }

        public virtual TBuilder Add<T>()
            where T : TItem, new()
        {
            return Add(new T());
        }

        public virtual TBuilder Remove(TItem item)
        {
            var key = GetKey(item);

            _collection.Remove(key);

            return This;
        }

        public virtual TBuilder Remove<T>()
            where T : TItem, new()
        {
            return Remove(new T());
        }

        public virtual TBuilder Clear()
        {
            _collection.Clear();

            return This;
        }

        public abstract string GetKey(TItem item);

        public virtual TCollection CreateCollection(IFactory factory)
        {
            var items = _collection.Select(x => x.Value as TItem);

            return factory.CreateInstance<TCollection>(items);
        }

        public virtual void RegisterWith(IRegister register)
        {
            register.Register(CreateCollection, Lifetime.Singleton);
        }
    }
}