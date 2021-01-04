using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Text;

namespace BookDemo.S08.S810
{
    class S810 : IBookDemo
    {
        public void Main()
        {
            var listener = new DatabaseSourceListener();
            DatabaseSource.Instance.OnCommandExecute(CommandType.Text, "SELECT * FROM T_USER");
        }
        
    }
    [EventSource(Name = "Artech-Data-SqlClient")]
    public sealed class DatabaseSource : EventSource
    {
        public static DatabaseSource Instance = new DatabaseSource();
        private DatabaseSource() { }

        [Event(1, Level = EventLevel.Informational, Keywords = EventKeywords.None, Opcode = EventOpcode.Info, Task = Tasks.DA, Tags = Tags.MSSQL, Version = 1,
            Message = "Execute SQL command. Type: {0}, Command Text: {1}")]
        public void OnCommandExecute(CommandType commandType, string commandText)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All, EventChannel.Debug))
            {
                WriteEvent(1, (int)commandType, commandText);
            }
        }
    }
    public class Tags
    {
        public const EventTags MSSQL = (EventTags)1;
        public const EventTags Oracle = (EventTags)2;
        public const EventTags Db2 = (EventTags)3;
    }
    public class Tasks
    {
        public const EventTask UI = (EventTask)1;
        public const EventTask Business = (EventTask)2;
        public const EventTask DA = (EventTask)3;
    }
    public class DatabaseSourceListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "Artech-Data-SqlClient")
            {
                EnableEvents(eventSource, EventLevel.LogAlways);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            Console.WriteLine($"EventId: {eventData.EventId}");
            Console.WriteLine($"EventName: {eventData.EventName}");
            Console.WriteLine($"Channel: {eventData.Channel}");
            Console.WriteLine($"Keywords: {eventData.Keywords}");
            Console.WriteLine($"Level: {eventData.Level}");
            Console.WriteLine($"Message: {eventData.Message}");
            Console.WriteLine($"Opcode: {eventData.Opcode}");
            Console.WriteLine($"Tags: {eventData.Tags}");
            Console.WriteLine($"Task: {eventData.Task}");
            Console.WriteLine($"Version: {eventData.Version}");
            Console.WriteLine($"Payload");
            var index = 0;
            foreach (var payloadName in eventData.PayloadNames)
            {
                Console.WriteLine($"\t{payloadName}:{eventData.Payload[index++]}");
            }
        }
    }
    
}
