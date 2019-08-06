using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace S01.AspNetCoreMvcAreas.Areas.Product.Controllers
{
    [Area("product")]
 
    public class GoodsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}