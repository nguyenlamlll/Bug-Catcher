using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCatcher.Web.Extensions
{
    public class UserHelper
    {
        private IHttpContextAccessor httpContextAccessor;
        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get current logged-in user.
        /// </summary>
        /// <returns></returns>
        public Guid GetCurrentUserId()
        {
            var currentUserId = Guid.Parse(httpContextAccessor.HttpContext
                .User.Claims.ToList()[0].Value);
            return currentUserId;
        }
    }
}
