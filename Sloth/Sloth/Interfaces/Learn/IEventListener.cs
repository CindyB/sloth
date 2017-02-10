using System.Windows.Forms;

namespace Sloth.Interfaces.Learn
{

    public interface IEventListener : IMessageFilter
    {

        void Start();

    }
}