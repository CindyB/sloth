using Sloth.Core;

namespace Sloth.Core
{
    public class SlothEvent : ISlothEvent
    {
        public SlothEvent()
        {
            ControlName = string.Empty;
            Message = uint.MinValue;
            WindowsName = string.Empty;
        }

        public SlothEvent(string windowsName,string controlName,uint message)
        {
            ControlName = controlName;
            Message = message;
            WindowsName = windowsName;
        }

        public string ControlName { get; set; }

        public uint Message { get; set; }

        public string WindowsName { get; set; }
    }

}
