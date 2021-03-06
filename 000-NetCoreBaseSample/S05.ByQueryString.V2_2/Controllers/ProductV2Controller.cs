﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace S05.ByQueryString.V2_2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/product")]
    [ApiController]
    public class ProductV2Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Huwei Phone V2", "Xiaomi Phone V2", "Vivo Phone V2" };
        }
    }
}