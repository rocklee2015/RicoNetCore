using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace S05.ByQueryString.V2_2.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    [ApiController]
    public class ProductV1Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Huwei Phone V1", "Xiaomi Phone V1", "Vivo Phone V1" };
        }
    }
}
