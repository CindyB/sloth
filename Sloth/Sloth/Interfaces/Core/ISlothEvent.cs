namespace Sloth.Core
{ 

    public interface ISlothEvent
    {

        string ControlName { get; set; }

        uint Message { get; set; }

        string WindowsName { get; set; }
    }

}
