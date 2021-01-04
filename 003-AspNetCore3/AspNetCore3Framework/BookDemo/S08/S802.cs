using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BookDemo.S08.S802
{
    public class S802 : IBookDemo
    {
        public void Main()
        {
            var source = new TraceSource("Foobar", SourceLevels.Warning);
            var eventTypes = (TraceEventType[])Enum.GetValues(typeof(TraceEventType));
            var eventId = 1;
            Array.ForEach(eventTypes, it => source.TraceEvent(it, eventId++, $"This is a {it} message."));
        }
    }
}
