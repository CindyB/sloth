using Sloth.Interfaces.Core;

namespace Sloth.Core
{
    public class SlothEvent : ISlothEvent
    {
        private string controlName;
        private uint message;
        private string windowsName;

        public SlothEvent()
        {
            controlName = string.Empty;
            message = uint.MinValue;
            windowsName = string.Empty;
        }

        public SlothEvent(string windowsName,string controlName,uint message)
        {
            this.controlName = controlName;
            this.message = message;
            this.windowsName = windowsName;
        }

        public string ControlName
        {
            get
            {
                return controlName;
            }

            set
            {
                controlName = value;
            }
        }

        public uint Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public string WindowsName
        {
            get
            {
                return windowsName;
            }

            set
            {
                windowsName = value;
            }
        }
    }

}
