using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S04.WebApiJwtBearer.Filters
{
    /// <summary>
    /// web api 接口管理权限
    /// </summary>
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public const string AuthenticationScheme = "ApiAuthenticationScheme";
        public ApiAuthorizeAttribute()
        {
            this.AuthenticationSchemes = AuthenticationScheme;
        }
    }
}
