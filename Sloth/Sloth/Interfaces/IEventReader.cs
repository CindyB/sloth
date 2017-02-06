namespace Sloth.Interfaces
{

    public interface IEventReader
    {

        ISlothEvent[] ReadEvents(string filePath);

    }

}
