using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BookDemo.S08.S803
{
    public class S803 : IBookDemo
    {
        public void Main()
        {
            var source = new TraceSource("Foobar", SourceLevels.Warning);
            source.Listeners.Add(new ConsoleTraceListener());
            var eventTypes = (TraceEventType[])Enum.GetValues(typeof(TraceEventType));
            var eventId = 1;
            Array.ForEach(eventTypes, it => source.TraceEvent(it, eventId++, $"This is a {it} message."));
        }
    }
    public class ConsoleTraceListener : TraceListener
    {
        public override void Write(string message) => Console.Write(message);
        public override void WriteLine(string message) => Console.WriteLine(message);
    }
}
