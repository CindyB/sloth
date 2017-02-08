namespace Sloth.Interfaces
{ 

    public interface ISlothEvent
    {
        string ClassName { get; set; }

        string WindowsName { get; set; }

        string ControlName { get; set; }
    }

}
