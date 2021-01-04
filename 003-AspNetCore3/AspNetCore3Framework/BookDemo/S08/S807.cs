using Microsoft.Extensions.DiagnosticAdapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace BookDemo.S08.S807
{
    class S807 : IBookDemo
    {
        public void Main()
        {
            DiagnosticListener.AllListeners.Subscribe(new Observer<DiagnosticListener>(listener => {
                if (listener.Name == "Artech-Data-SqlClient")
                {
                    listener.SubscribeWithAdapter(new DatabaseSourceCollector());
                }
            }));

            var source = new DiagnosticListener("Artech-Data-SqlClient");
            source.Write("CommandExecution", new { CommandType = CommandType.Text, CommandText = "SELECT * FROM T_USER" });
        }
    }
    public class DatabaseSourceCollector
    {
        //需要安装包：Microsoft.Extensions.DiagnosticAdapter
        [DiagnosticName("CommandExecution")]
        public void OnCommandExecute(CommandType commandType, string commandText)
        {
            Console.WriteLine($"Event Name: CommandExecution");
            Console.WriteLine($"CommandType: {commandType}");
            Console.WriteLine($"CommandText: {commandText}");
        }
    }
    public class Observer<T> : IObserver<T>
    {
        private Action<T> _onNext;
        public Observer(Action<T> onNext) => _onNext = onNext;

        public void OnCompleted() { }
        public void OnError(Exception error) { }
        public void OnNext(T value) => _onNext(value);
    }
}
