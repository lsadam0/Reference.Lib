using System;
using System.Collections.Generic;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Observable : IObservable<StateMessage>
    {
        private readonly HashSet<IObserver<StateMessage>> stateObservers;

        public Observable()
        {
            stateObservers = new HashSet<IObserver<StateMessage>>();
        }

        public virtual IDisposable Subscribe(IObserver<StateMessage> observer)
        {
            if (observer != null)
                if (!stateObservers.Contains(observer))
                    stateObservers.Add(observer);

            return new Unsubscribe<IObserver<StateMessage>>(RemoveSubscriber, observer);
        }

        private bool RemoveSubscriber(IObserver<StateMessage> subscriber)
        {
            if (stateObservers.Contains(subscriber))
            {
                stateObservers.Remove(subscriber);

                return true;
            }

            return false;
        }

        public void NotifyOfStateChange()
        {
            var message = new StateMessage(string.Format("State changed @ {0}", DateTime.Now.ToString()));

            foreach (var observer in stateObservers)
                observer.OnNext(message);
        }
    }
}