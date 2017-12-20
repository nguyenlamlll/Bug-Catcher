using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugCatcher.Web.Pages.Dashboard
{
    public static class DashboardNavPages
    {
        public static string Index => "Index";

        public static string Company => "IndexCompany";

        public static string ExternalLogins => "ExternalLogins";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string CompanyNavClass(ViewContext viewContext) => SubPageNavClass(viewContext, Company);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);
    
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static string SubPageNavClass(ViewContext viewContext, string subPage)
        {
            var path = System.IO.Path.GetFullPath(viewContext.ActionDescriptor.DisplayName);
            var parts = path.Split("\\");
            string activePage = String.Format("{0}{1}", parts[parts.Length - 1], parts[parts.Length - 2]);
            return string.Equals(activePage, subPage, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
