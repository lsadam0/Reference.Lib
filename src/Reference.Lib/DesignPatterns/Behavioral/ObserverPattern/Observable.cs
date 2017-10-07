using System;
using System.Collections.Generic;
using System.Globalization;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Observable : IObservable<StateMessage>
    {
        private readonly HashSet<IObserver<StateMessage>> _stateObservers;

        public Observable()
        {
            _stateObservers = new HashSet<IObserver<StateMessage>>();
        }

        public virtual IDisposable Subscribe(IObserver<StateMessage> observer)
        {
            if (observer != null)
                if (!_stateObservers.Contains(observer))
                    _stateObservers.Add(observer);

            return new Unsubscribe<IObserver<StateMessage>>(RemoveSubscriber, observer);
        }

        private bool RemoveSubscriber(IObserver<StateMessage> subscriber)
        {
            if (_stateObservers.Contains(subscriber))
            {
                _stateObservers.Remove(subscriber);

                return true;
            }

            return false;
        }

        public void NotifyOfStateChange()
        {
            var message = new StateMessage(string.Format("State changed @ {0}", DateTime.Now.ToString(CultureInfo.CurrentCulture)));

            foreach (var observer in _stateObservers)
                observer.OnNext(message);
        }
    }
}