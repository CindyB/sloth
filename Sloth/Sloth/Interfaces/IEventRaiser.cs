namespace Sloth.Interfaces
{

    public interface IEventRaiser
    {

        void RaiseSlothEvent(ISlothEvent eventToRaise);

    }

}
