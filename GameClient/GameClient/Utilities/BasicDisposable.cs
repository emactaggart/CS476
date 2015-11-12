using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Utilities
{
    class BasicDisposable<T> : IDisposable
    {
        List<IObserver<T>> _observerList;
        IObserver<T> _observer;

        public BasicDisposable(List<IObserver<T>> observerList, IObserver<T> observer)
        {
            _observerList = observerList;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observerList != null && _observerList.Contains(_observer))
            {
                _observerList.Remove(_observer);
            }
        }
    }
}
