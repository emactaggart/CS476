using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClient.Models;

namespace GameClient.Utilities
{
    class BasicObservable<T> : IObservable<T>
    {
        private T _data;
        private List<IObserver<T>> _observerList;

        public BasicObservable(T data)
        {
            _data = data;
            _observerList = new List<IObserver<T>>();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (_observerList.Contains(observer))
            {
                _observerList.Add(observer);
                Notify();
            }
            return new BasicDisposable<T>(_observerList, observer);
        }

        public void Update(T data)
        {
            _data = data;
            Notify();
        }

        public void Notify()
        {
            _observerList.ForEach(x => x.OnNext(_data));
        }

        public void Destroy()
        {
            _observerList.RemoveAll(_ => true);
        }
    }
}
