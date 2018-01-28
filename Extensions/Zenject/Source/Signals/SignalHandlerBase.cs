using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject
{
    public abstract class SignalHandlerBase : ISignalHandler, IDisposable, IInitializable, IValidatable
    {
        readonly SignalManager _manager;
        readonly BindingId _signalId;

        [Inject]
        public SignalHandlerBase(
            BindingId signalId, SignalManager manager)
        {
            _manager = manager;
            _signalId = signalId;
        }

        public void Initialize()
        {
            _manager.Register(_signalId, this);
        }

        public void Dispose()
        {
            _manager.Unregister(_signalId, this);
        }

        protected void ValidateParameter<T>(object value)
        {
            if (value == null)
            {
                Assert.That(!typeof(T).IsValueType());
            }
            else
            {
                Assert.That(value.GetType().DerivesFromOrEqual<T>());
            }
        }

        public virtual void Validate()
        {
            // optional
        }

        public abstract void Execute(object[] args);
    }
}


