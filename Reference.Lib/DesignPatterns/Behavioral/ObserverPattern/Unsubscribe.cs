using System;

namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class Unsubscribe<T> : IDisposable
    {
        private Func<T, bool> unsubscribeMethod;

        private T toUnsubscribe;

        public Unsubscribe(Func<T, bool> method, T observer)
        {
            this.unsubscribeMethod = method;
            this.toUnsubscribe = observer;
        }

        public void Dispose()
        {
            if (this.unsubscribeMethod != null)
            {
                this.unsubscribeMethod(this.toUnsubscribe);
                this.unsubscribeMethod = null;
            }
        }
    }
}
