using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S00.Models
{
    /// <summary>
    /// 用户返回结果
    /// </summary>
    public class UserOutput : UserInput
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
