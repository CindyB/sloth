Imports Sloth.Sloth.Interfaces
Imports Sloth.Sloth.Log

namespace Sloth.Automation

    public Class EventConverter
        Implements IEventConverter

        public Function ConvertToSlothEvents(lines As String()) As ISlothEvent() Implements IEventConverter.ConvertToSlothEvents
            Throw New NotImplementedException()
        End Function
    End Class

}
