using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Utilities
{
    class BasicObserver<T> : IObserver<T>
    {
        private IDisposable _disposable;
        private T _data;

        public BasicObserver()
        {
        }

        public T GetValue()
        {
            return _data;
        }

        public void Subscribe(IObservable<T> observable)
        {
            if (observable != null)
            {
                _disposable = observable.Subscribe(this);
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(T value)
        {
            _data = value;
        }
    }
}
