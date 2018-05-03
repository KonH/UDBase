using System;
using System.Collections.Generic;
using ModestTree;
using ModestTree.Util;

#if ZEN_SIGNALS_ADD_UNIRX
using UniRx;
#endif

namespace Zenject
{
    // This is just used for generic constraints
    public interface ISignal<TParam1, TParam2, TParam3> : ISignalBase
    {
        void Fire(TParam1 p1, TParam2 p2, TParam3 p3);

        void Listen(Action<TParam1, TParam2, TParam3> listener);
        void Unlisten(Action<TParam1, TParam2, TParam3> listener);
    }

    public abstract class Signal<TDerived, TParam1, TParam2, TParam3> : SignalBase, ISignal<TParam1, TParam2, TParam3>
        where TDerived : Signal<TDerived, TParam1, TParam2, TParam3>
    {
        readonly List<Action<TParam1, TParam2, TParam3>> _listeners = new List<Action<TParam1, TParam2, TParam3>>();
#if ZEN_SIGNALS_ADD_UNIRX
        readonly Subject<Tuple<TParam1, TParam2, TParam3>> _observable = new Subject<Tuple<TParam1, TParam2, TParam3>>();
#endif
        readonly List<Action<TParam1, TParam2, TParam3>> _tempListeners = new List<Action<TParam1, TParam2, TParam3>>();

#if ZEN_SIGNALS_ADD_UNIRX
        public IObservable<Tuple<TParam1, TParam2, TParam3>> AsObservable
        {
            get
            {
                return _observable;
            }
        }
#endif

        public int NumListeners
        {
            get { return _listeners.Count; }
        }

        public void Listen(Action<TParam1, TParam2, TParam3> listener)
        {
            if (_listeners.Contains(listener))
            {
                throw Assert.CreateException(
                    "Tried to add method '{0}' to signal '{1}' but it has already been added", listener.ToDebugString(), this.GetType());
            }

            _listeners.Add(listener);
        }

        public void Unlisten(Action<TParam1, TParam2, TParam3> listener)
        {
            bool success = _listeners.Remove(listener);

            if (!success)
            {
                throw Assert.CreateException(
                    "Tried to remove method '{0}' from signal '{1}' without adding it first", listener.ToDebugString(), this.GetType());
            }
        }

        public static TDerived operator + (Signal<TDerived, TParam1, TParam2, TParam3> signal, Action<TParam1, TParam2, TParam3> listener)
        {
            signal.Listen(listener);
            return (TDerived)signal;
        }

        public static TDerived operator - (Signal<TDerived, TParam1, TParam2, TParam3> signal, Action<TParam1, TParam2, TParam3> listener)
        {
            signal.Unlisten(listener);
            return (TDerived)signal;
        }

        public void Fire(TParam1 p1, TParam2 p2, TParam3 p3)
        {
#if UNITY_EDITOR && ZEN_PROFILING_ENABLED
            using (ProfileBlock.Start("Signal '{0}'", this.GetType().Name))
#endif
            {
                var wasHandled = Manager.Trigger(SignalId, new object[] { p1, p2, p3 });

                wasHandled |= (_listeners.Count > 0);

                // Iterate over _tempListeners in case the
                // listener removes themselves in the callback
                // (we use _tempListeners to avoid memory allocs)
                _tempListeners.Clear();

                for (int i = 0; i < _listeners.Count; i++)
                {
                    _tempListeners.Add(_listeners[i]);
                }

                for (int i = 0; i < _tempListeners.Count; i++)
                {
                    var listener = _tempListeners[i];

#if UNITY_EDITOR && ZEN_PROFILING_ENABLED
                    using (ProfileBlock.Start(listener.ToDebugString()))
#endif
                    {
                        listener(p1, p2, p3);
                    }
                }

#if ZEN_SIGNALS_ADD_UNIRX
                wasHandled |= _observable.HasObservers;
#if UNITY_EDITOR && ZEN_PROFILING_ENABLED
                using (ProfileBlock.Start("UniRx Stream"))
#endif
                {
                    _observable.OnNext(Tuple.Create(p1, p2, p3));
                }
#endif

                if (Settings.RequiresHandler && !wasHandled)
                {
                    throw Assert.CreateException(
                        "Signal '{0}' was fired but no handlers were attached and the signal is marked to require a handler!", SignalId);
                }
            }
        }
    }
}


