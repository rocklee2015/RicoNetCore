using System;
using System.Collections.Generic;
using System.Text;

namespace S02_ReadAppsettingConfig
{
    public class LoggingOptions
    {
        public bool IncludeScopes { get; set; }

        public LogLevelOptions LogLevel { get; set; }
    }
}
