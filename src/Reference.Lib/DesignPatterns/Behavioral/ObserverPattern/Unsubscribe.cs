using System;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Unsubscribe<T> : IDisposable
    {
        private readonly T _toUnsubscribe;
        private Func<T, bool> _unsubscribeMethod;

        public Unsubscribe(Func<T, bool> method, T observer)
        {
            _unsubscribeMethod = method;
            _toUnsubscribe = observer;
        }

        public void Dispose()
        {
            if (_unsubscribeMethod != null)
            {
                _unsubscribeMethod(_toUnsubscribe);
                _unsubscribeMethod = null;
            }
        }
    }
}