﻿Imports System.IO
Imports System.Reflection
Imports Rhino.Mocks
Imports Sloth.Sloth.Automation
Imports Sloth.Sloth.Interfaces

namespace Sloth.UnitTests.Automation

    <TestClass()>
    public Class EventReaderTest

        private m_EventConverter As IEventConverter
        private m_FileAdapter As IFileAdapter
        private m_Target As IEventReader

        <TestInitialize>
        public void TestInitialize()
            m_EventConverter = MockRepository.GenerateMock(Of IEventConverter)()
            m_FileAdapter = MockRepository.GenerateMock(Of IFileAdapter)()

            m_Target = New EventReader()
            m_Target.GetType().GetField("m_EventConverter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, m_EventConverter)
            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, m_FileAdapter)
        End void

        <TestCleanup>
        public void TestCleanup()
            m_EventConverter = Nothing
            m_FileAdapter = Nothing

            m_Target.GetType().GetField("m_EventConverter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, Nothing)
            m_Target.GetType().GetField("m_FileAdapter", BindingFlags.NonPublic Or BindingFlags.Instance).SetValue(m_Target, Nothing)
            m_Target = Nothing
        End void

        <TestMethod()>
        public void GivenFilePath_WhenReadEvents_ThenAllLinesOfFileAreRead()
            Dim filePath As String = Me.GetType.Assembly.Location

            m_Target.ReadEvents(filePath)

            m_FileAdapter.AssertWasCalled(Function(x) x.ReadAllLines(filePath))
        End void

        <TestMethod()>
        public void GivenLinesOfFile_WhenReadEvents_ThenLinesAreConvertedToSlothEvents()
            Dim filePath As String = Me.GetType.Assembly.Location
            Dim lines As String() = {"MyButton;Click"}
            m_FileAdapter.Expect(Function(x) x.ReadAllLines(filePath)).Return(lines)

            m_Target.ReadEvents(filePath)

            m_EventConverter.AssertWasCalled(Function(x) x.ConvertToSlothEvents(lines))
        End void

        <TestMethod()>
        public void GivenFilePath_WhenReadEvents_ThenConvertedEventsAreReturned()
            Dim filePath As String = Me.GetType.Assembly.Location
            Dim lines As String() = {"MyButton;Click"}
            m_FileAdapter.Expect(Function(x) x.ReadAllLines(filePath)).Return(lines)
            Dim expected As ISlothEvent() = {MockRepository.GenerateMock(Of ISlothEvent), MockRepository.GenerateMock(Of ISlothEvent)}
            m_EventConverter.Expect(Function(x) x.ConvertToSlothEvents(lines)).Return(expected)

            Dim actual As ISlothEvent() = m_Target.ReadEvents(filePath)

            Assert.AreSame(expected, actual)
        End void

    End Class

}