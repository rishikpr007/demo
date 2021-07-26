using demo.Filters;
using demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
        [TypeFilter(typeof(CustomAuthorizationFilterAttribute))]
        public class DefaultController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }


    }
}
