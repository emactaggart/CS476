using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Utilities
{
    public class BasicObservable<T> : IObservable<T>
    {
        public T data { get; private set; }
        private List<IObserver<T>> _observerList;

        public BasicObservable(T data)
        {
            this.data = data;
            _observerList = new List<IObserver<T>>();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!_observerList.Contains(observer))
            {
                _observerList.Add(observer);
                Notify();
            }
            return new BasicDisposable<T>(_observerList, observer);
        }

        public void Update(T data)
        {
            this.data = data;
            Notify();
        }

        public void Notify()
        {
            _observerList.ForEach(x => x.OnNext(data));
        }

        public void Destroy()
        {
            _observerList.RemoveAll(_ => true);
            data = default(T);
        }
    }
}
