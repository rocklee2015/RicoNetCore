using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S00.NetCoreModels.User;

namespace S01.WebApiSwagger.Controllers
{
    /// <summary>
    /// 用户管理中心
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public static List<UserOutput> Users { get; set; }

        /// <summary>
        /// 集合获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserOutput>> Get()
        {
            return Users;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UserOutput> Get(int id)
        {
            return Users.SingleOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// 用户提交
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult<bool> Post([FromBody]UserInput input)
        {
            Users.Add(new UserOutput() { Id = 3, UserName = input.UserName, Age = input.Age, Mobile = input.Mobile });
            return true;
        }

        /// <summary>
        /// 用户提交
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Age"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        [HttpPost("Post-Form")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult<bool> Post(string UserName,int Age,string Mobile)
        {
            Users.Add(new UserOutput() { Id = 3, UserName = UserName, Age = Age, Mobile = Mobile });
            return true;
        }

        /// <summary>
        /// 用户提交
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("SumbitSchool")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult<bool> SumbitSchool([FromForm]School input)
        {
            
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        static UserController()
        {
            Users = new List<UserOutput>(){
                new UserOutput(){Id=1, UserName="ricolee",Age=18, Mobile="12345678912", CreateTime=DateTime.Now  },
                 new UserOutput(){Id=2, UserName="刘备",Age=38, Mobile="12345678912", CreateTime=DateTime.Now  }
            };
        }

    }
}