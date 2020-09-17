using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ASPDotNetCoreWithVue.Controllers
{
    public class RoutesController : Controller
    {
        private RoutesService _routesService;

        public RoutesController(RoutesService routesService)
        {
            _routesService = routesService;
        }

        public JsonResult Get()
        {
            var route = _routesService.Get().ToList();
            return new JsonResult(new { code= 20000, data=route});
        }
        public JsonResult Add()
        {
            return new JsonResult("");
        }

        public JsonResult Delete(int Id)
        {
            return new JsonResult("");
        }
    }
}
