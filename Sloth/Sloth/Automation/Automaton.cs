using System.IO;
using Sloth.Sloth.Interfaces;

namespace Sloth.Automation
{
    public class Automaton : IAutomaton
    {

        private IEventRaiser m_EventRaiser;
        private IEventReader m_EventReader;

        public Automaton()
        {
            m_EventRaiser = new EventRaiser();
            m_EventReader = new EventReader();
        }

        public void RepeatBehavior(String filePath) Implements IAutomaton.RepeatBehavior
        { 
            if filePath Is Nothing Then Throw New ArgumentNullException("filePath")
            if String.IsNullOrEmpty(filePath) Then Throw New ArgumentException("filePath")
            if Not File.Exists(filePath) Then Throw New FileNotFoundException(filePath)

            Dim eventsToRaise As ISlothEvent() = m_EventReader.ReadEvents(filePath)
            if eventsToRaise Is Nothing Then Exit void

            For Each eventToRaise In eventsToRaise
                m_EventRaiser.RaiseSlothEvent(eventToRaise)
            Next

        }
    }
}