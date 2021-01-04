using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Text;

namespace BookDemo.S08.S804
{
    public class S804 : IBookDemo
    {
        public void Main()
        {
            DatabaseSource.Instance.OnCommandExecute(CommandType.Text, "SELECT * FROM T_USER");
        }
    }
    public sealed class DatabaseSource : EventSource
    {
        public static readonly DatabaseSource Instance = new DatabaseSource();
        private DatabaseSource() { }
        public void OnCommandExecute(CommandType commandType, string commandText) => WriteEvent(1, commandType, commandText);
    }
}
