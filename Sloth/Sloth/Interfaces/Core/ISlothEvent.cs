namespace Sloth.Interfaces.Core
{ 

    public interface ISlothEvent
    {
        string ClassName { get; set; }

        string WindowsName { get; set; }

        string ControlName { get; set; }
    }

}
