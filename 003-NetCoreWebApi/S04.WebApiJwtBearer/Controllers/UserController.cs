﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S00.NetCoreModels.User;

namespace S04.WebApiJwtBearer.Controllers
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
        /// 
        /// </summary>
        static UserController()
        {
            Users = new List<UserOutput>(){
                new UserOutput(){Id=1, UserName="ricolee",Age=18, Mobile="12345678912", CreateTime=DateTime.Now  },
                 new UserOutput(){Id=2, UserName="刘备",Age=38, Mobile="12345678912", CreateTime=DateTime.Now  }
            };
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserOutput>> Get()
        {
            return Users;
        }

        /// <summary>
        /// 根据ID获取用户
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
    }
}