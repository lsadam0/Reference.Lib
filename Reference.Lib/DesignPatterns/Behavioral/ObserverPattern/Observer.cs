using System;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Observer : IObserver<StateMessage>, IDisposable
    {
        private readonly IDisposable unsubscriber;

        public Observer(IObservable<StateMessage> observable)
        {
            if (observable != null)
                unsubscriber = observable.Subscribe(this);
        }

        public void Dispose()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Inform("OnCompleted");
        }

        public void OnError(Exception error)
        {
            if (error != null)
                Inform("OnError");
        }

        public void OnNext(StateMessage value)
        {
            if (value != null)
                Inform(value.Message);
        }

        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        private void Inform(string message)
        {
            Console.WriteLine(string.Format("Received - {0}", message));
        }
    }
}