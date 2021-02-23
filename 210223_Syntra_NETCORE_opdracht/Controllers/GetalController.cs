using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _210223_Syntra_NETCORE_opdracht.Controllers
{
    public class GetalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
