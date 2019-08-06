using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace S02.WebApiVersionControlQueryString.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/values
        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Huwei Phone V1", "Xiaomi Phone V1", "Vivo Phone V1" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Huwei Phone V1";
        }


    }
}
