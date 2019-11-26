using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace S05.ApVersion.V2_2.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    public class NeutralTestController : Controller
    {
        public IActionResult Index()
        {
            return Json("TEST");
        }
    }
}