using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S04.WebApiJwtBearer.Filters
{
    /// <summary>
    /// 后台管理员账户权限
    /// </summary>
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public const string AuthenticationScheme = "AdminAuthenticationScheme";
        public AdminAuthorizeAttribute()
        {
            this.AuthenticationSchemes = AuthenticationScheme;
        }
    }
}
