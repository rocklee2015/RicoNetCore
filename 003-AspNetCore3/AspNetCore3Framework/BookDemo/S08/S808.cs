using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BookDemo.S08.S808
{
    class S808 : IBookDemo
    {
        public void Main()
        {
            var source = new TraceSource("Foobar", SourceLevels.All);
            source.Listeners.Clear();
            source.Listeners.Add(new DefaultTraceListener { LogFileName = "trace.log" });
            var eventTypes = (TraceEventType[])Enum.GetValues(typeof(TraceEventType));
            var eventId = 1;
            Array.ForEach(eventTypes, it => source.TraceEvent(it, eventId++, $"This is a {it} message."));
        }
    }
}
