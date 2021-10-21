using Microsoft.AspNetCore.Mvc;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [SimpleDefaultAdminAuthorizationFilter]
    public class AdminBaseController : Controller
    {
        public AdminBaseController()
        {

        }
    }
}
