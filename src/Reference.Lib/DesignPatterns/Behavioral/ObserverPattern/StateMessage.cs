namespace Reference.Lib.DesignPatterns.Behavioral.ObserverPattern
{
    public class StateMessage
    {
        public StateMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}