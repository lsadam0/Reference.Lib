using System;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Observer : IObserver<StateMessage>, IDisposable
    {
        private readonly IDisposable _unsubscriber;

        public Observer(IObservable<StateMessage> observable)
        {
            if (observable != null)
                _unsubscriber = observable.Subscribe(this);
        }

        public void Dispose()
        {
            _unsubscriber.Dispose();
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
            _unsubscriber.Dispose();
        }

        private void Inform(string message)
        {
            Console.WriteLine(string.Format("Received - {0}", message));
        }
    }
}