namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class StateMessage
    {
        public string Message
        {
            get;
            private set;
        }

        public StateMessage(string message)
        {
            this.Message = message;
        }
    }
}