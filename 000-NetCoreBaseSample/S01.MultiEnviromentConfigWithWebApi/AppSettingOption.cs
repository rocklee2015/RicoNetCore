﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S01.MutiEnviromentConfigWebApi
{
    public class AppSettingOption
    {
        public string AppId { get; set; }

        public ConnectionOption ConnectionStrings { get; set; }
    }
    public class ConnectionOption
    {
        public string RicoDbContext { get; set; }
    }
}
