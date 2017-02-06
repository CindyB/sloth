using System.Windows.Forms;

namespace Sloth.Interfaces
{

    public interface IEventListener : IMessageFilter
    {

        void Start();

    }
}