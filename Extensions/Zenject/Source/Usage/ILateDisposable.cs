using System;

namespace Zenject
{
    public interface ILateDisposable
    {
        void LateDispose();
    }
}
