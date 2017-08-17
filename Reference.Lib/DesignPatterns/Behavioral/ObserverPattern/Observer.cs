using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Observer : IObserver<StateMessage>, IDisposable
    {
        private IDisposable unsubscriber;

        public Observer(IObservable<StateMessage> observable)
        {
            if (observable != null)
            {
                this.unsubscriber = observable.Subscribe(this);
            }
        }

        public void Dispose()
        {
                this.unsubscriber.Dispose();
        }

        public void Unsubscribe()
        {
                this.unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Inform("OnCompleted");
        }

        public void OnError(Exception error)
        {
            if (error != null)
            {
                Inform("OnError");
            }
        }

        public void OnNext(StateMessage value)
        {
            if (value != null)
            {
                Inform(value.Message);
            }
        }

        private void Inform(string message)
        {
            Console.WriteLine(string.Format("Received - {0}", message));
        }
    }

}