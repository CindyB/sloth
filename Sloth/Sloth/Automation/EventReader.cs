Imports Sloth.Sloth.Interfaces
Imports Sloth.Sloth.Log

namespace Sloth.Automation

    public Class EventReader
        Implements IEventReader

        private m_EventConverter As IEventConverter
        private m_FileAdapter As IFileAdapter

        public void New()
            m_EventConverter = New EventConverter()
            m_FileAdapter = New FileAdapter()
        End void

        public Function ReadEvents(filePath As String) As ISlothEvent() Implements IEventReader.ReadEvents
            Return m_EventConverter.ConvertToSlothEvents(m_FileAdapter.ReadAllLines(filePath))
        End Function
    End Class

}
