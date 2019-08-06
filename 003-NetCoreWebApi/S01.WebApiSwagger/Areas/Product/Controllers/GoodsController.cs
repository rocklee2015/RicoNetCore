using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace S01.WebApiSwagger.Areas.Product.Controllers
{
    /// <summary>
    /// 商品列表
    /// </summary>
    [Area("Product")]
    [Route("product/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        /// <summary>
        /// 集合获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "苹果手机", "华为手机","OPPO手机" };
        }
    }
}