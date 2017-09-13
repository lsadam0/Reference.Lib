using System;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Unsubscribe<T> : IDisposable
    {
        private readonly T toUnsubscribe;
        private Func<T, bool> unsubscribeMethod;

        public Unsubscribe(Func<T, bool> method, T observer)
        {
            unsubscribeMethod = method;
            toUnsubscribe = observer;
        }

        public void Dispose()
        {
            if (unsubscribeMethod != null)
            {
                unsubscribeMethod(toUnsubscribe);
                unsubscribeMethod = null;
            }
        }
    }
}