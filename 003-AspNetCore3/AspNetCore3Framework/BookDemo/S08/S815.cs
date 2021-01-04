using Microsoft.Extensions.DiagnosticAdapter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookDemo.S08.S815
{
    class S815 : IBookDemo
    {
        public void Main()
        {
            DiagnosticListener.AllListeners.Subscribe(listener =>
            {
                if (listener.Name == "Web")
                {
                    listener.SubscribeWithAdapter(new DiagnosticCollector());
                }
            });


            var source = new DiagnosticListener("Web");
            var stopwatch = Stopwatch.StartNew();
            if (source.IsEnabled("ReceiveRequest"))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://www.artech.top");
                source.Write("ReceiveRequest", new
                {
                    Request = request,
                    Timestamp = Stopwatch.GetTimestamp()
                });
            }
            Task.Delay(100).Wait();
            if (source.IsEnabled("SendReply"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                source.Write("SendReply", new
                {
                    Response = response,
                    Elaped = stopwatch.Elapsed
                });
            }
        }
    }
    public sealed class DiagnosticCollector
    {
        [DiagnosticName("ReceiveRequest")]
        public void OnReceiveRequest(HttpRequestMessage request, long timestamp)
        => Console.WriteLine($"Receive request. Url: {request.RequestUri}; Timstamp:{timestamp}");

        [DiagnosticName("SendReply")]
        public void OnSendReply(HttpResponseMessage response, TimeSpan elaped)
        => Console.WriteLine($"Send reply. Status code: {response.StatusCode}; Elaped: {elaped}");
    }
}
