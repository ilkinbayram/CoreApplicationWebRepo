using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Controllers
{
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
