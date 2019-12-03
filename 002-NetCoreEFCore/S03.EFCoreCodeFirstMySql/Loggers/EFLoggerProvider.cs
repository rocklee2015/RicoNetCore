﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace S03.EFCoreCodeFirstMySql.Loggers
{
    public class EFLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new EFLogger(categoryName);
        public void Dispose() { }
    }
    public class EFLogger : ILogger
    {
        private readonly string categoryName;

        public EFLogger(string categoryName) => this.categoryName = categoryName;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //ef core执行数据库查询时的categoryName为Microsoft.EntityFrameworkCore.Database.Command,日志级别为Information
            if ( logLevel == LogLevel.Information)
            {
                var logContent = formatter(state, exception);
                //TODO: 拿到日志内容想怎么玩就怎么玩吧
                Console.WriteLine();
                //Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logContent);
                Console.ResetColor();
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}
