namespace DroneStudio.ApplicationLogic.Messages
{
    public interface IMessageParser
    {
        IMessage TryParse(string line);
    }
}
