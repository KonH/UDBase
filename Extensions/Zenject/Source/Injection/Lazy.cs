using System;
using ModestTree;

namespace Zenject
{
    public interface ILazy
    {
        void Validate();
    }

    [ZenjectAllowDuringValidationAttribute]
    public class Lazy<T> : ILazy
    {
        readonly DiContainer _container;
        readonly InjectContext _context;

        bool _hasValue;
        T _value;

        public Lazy(DiContainer container, InjectContext context)
        {
            Assert.IsEqual(typeof(T), context.MemberType);

            _container = container;
            _context = context;
        }

        void ILazy.Validate()
        {
            _container.Resolve(_context);
        }

        public T Value
        {
            get
            {
                if (!_hasValue)
                {
                    _value = (T)_container.Resolve(_context);
                    _hasValue = true;
                }

                return _value;
            }
        }
    }
}
