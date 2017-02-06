Imports Sloth.Sloth.Interfaces

namespace Sloth.Automation

    public Class EventRaiser
        Implements IEventRaiser

        public void RaiseSlothEvent(eventToRaise As ISlothEvent) Implements IEventRaiser.RaiseSlothEvent
            Throw New NotImplementedException()
        End void
    End Class

}
