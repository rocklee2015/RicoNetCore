using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Text;

namespace BookDemo.S08.S805
{
    class S805 : IBookDemo
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
        public static readonly DatabaseSource Instance = new DatabaseSource();
        private DatabaseSource() { }
        [Event(1)]
        public void OnCommandExecute(CommandType commandType, string commandText) => WriteEvent(1, commandType, commandText);
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
            Console.WriteLine($"Payload");
            var index = 0;
            foreach (var payloadName in eventData.PayloadNames)
            {
                Console.WriteLine($"\t{payloadName}:{eventData.Payload[index++]}");
            }
        }
    }
}
