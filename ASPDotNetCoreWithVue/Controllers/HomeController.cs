using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPDotNetCoreWithVue.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            return new JsonResult(new { code = 20000 });
        }
    }
}
