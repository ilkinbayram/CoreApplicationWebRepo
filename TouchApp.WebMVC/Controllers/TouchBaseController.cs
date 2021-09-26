using Microsoft.AspNetCore.Mvc;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Controllers
{
    [LocalizationFilter]
    public class TouchBaseController : Controller
    {
        public override ViewResult View()
        {

            return base.View();
        }
        public override ViewResult View(object model)
        {

            return base.View(model);
        }
        public override ViewResult View(string viewName)
        {

            return base.View(viewName);
        }
        public override ViewResult View(string viewName, object model)
        {

            return base.View(viewName, model);
        }
    }
}
