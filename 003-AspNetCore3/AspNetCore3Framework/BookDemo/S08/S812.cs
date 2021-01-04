using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BookDemo.S08.S812
{
    class S812 : IBookDemo
    {
        static readonly Random _random = new Random();

        public void Main()
        {
            Main1().GetAwaiter();
        }

        public  async Task Main1()
        {
            File.AppendAllLines("log.csv",
                new string[] { "EventName,StartTime,Elapsed,ActivityId,RelatedActivityId" });
            var listener = new FoobarListener();
            await FooAsync();
        }

         Task FooAsync() => InvokeAsync(FoobarSource.Instance.FooStart,
            FoobarSource.Instance.FooStop, async () =>
            {
                await BarAsync();
                await GuxAsync();
            });
         Task BarAsync() => InvokeAsync(FoobarSource.Instance.BarStart,
            FoobarSource.Instance.BarStop, BazAsync);

         Task BazAsync() => InvokeAsync(FoobarSource.Instance.BazStart,
            FoobarSource.Instance.BazStop, () => Task.CompletedTask);

         Task GuxAsync() => InvokeAsync(FoobarSource.Instance.GuxStart,
            FoobarSource.Instance.GuxStop, () => Task.CompletedTask);

         async Task InvokeAsync(Action<long> start, Action<double> stop, Func<Task> body)
        {
            start(Stopwatch.GetTimestamp());
            var sw = Stopwatch.StartNew();
            await Task.Delay(_random.Next(10, 100));
            await body();
            stop(sw.ElapsedMilliseconds);
        }

       
    }
    public sealed class FoobarListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == "System.Threading.Tasks.TplEventSource")
            {
                EnableEvents(eventSource, EventLevel.Informational, (EventKeywords)0x80);
            }

            if (eventSource.Name == "Foobar")
            {
                EnableEvents(eventSource, EventLevel.LogAlways);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventSource.Name == "Foobar")
            {
                var timestamp = eventData.PayloadNames[0] == "timestamp"
                    ? eventData.Payload[0]
                    : "";
                var elapsed = eventData.PayloadNames[0] == "elapsed"
                    ? eventData.Payload[0]
                    : "";
                var relatedActivityId = eventData.RelatedActivityId == default
                    ? ""
                    : eventData.RelatedActivityId.ToString();
                var line = $"{eventData.EventName},{timestamp},{elapsed},{ eventData.ActivityId},{ relatedActivityId}";
                File.AppendAllLines("log.csv", new string[] { line });
            }
        }
    }
    [EventSource(Name = "Foobar")]
    public sealed class FoobarSource : EventSource
    {
        public static FoobarSource Instance = new FoobarSource();

        [Event(1)]
        public void FooStart(long timestamp) => WriteEvent(1, timestamp);
        [Event(2)]
        public void FooStop(double elapsed) => WriteEvent(2, elapsed);

        [Event(3)]
        public void BarStart(long timestamp) => WriteEvent(3, timestamp);
        [Event(4)]
        public void BarStop(double elapsed) => WriteEvent(4, elapsed);

        [Event(5)]
        public void BazStart(long timestamp) => WriteEvent(5, timestamp);
        [Event(6)]
        public void BazStop(double elapsed) => WriteEvent(6, elapsed);

        [Event(7)]
        public void GuxStart(long timestamp) => WriteEvent(7, timestamp);
        [Event(8)]
        public void GuxStop(double elapsed) => WriteEvent(8, elapsed);
    }
}
