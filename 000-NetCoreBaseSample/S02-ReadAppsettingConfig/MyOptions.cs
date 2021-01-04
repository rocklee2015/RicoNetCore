using System;
using System.Collections.Generic;
using System.Text;

namespace S02_ReadAppsettingConfig
{
    public class MyOptions
    {
        public int AppId { get; set; }

        public LoggingOptions Logging { get; set; }

        public List<RoleName> RoleNames { get; set; }

    }
    public class RoleName
    {
        public string Name { get; set; }
    }
    public class CORSOption
    {
        public List<string> Allow { get; set; }
    }
}
