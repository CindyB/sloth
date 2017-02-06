namespace Sloth.Interfaces
{

    public interface IEventConverter
    {

        ISlothEvent[] ConvertToSlothEvents(string[] lines);

    }

}
