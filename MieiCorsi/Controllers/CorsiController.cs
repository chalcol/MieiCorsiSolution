using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MieiCorsi.Controllers
{
    public class CorsiController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono Index");
        }

        public IActionResult Details(String id)
        {
            return Content($"sono detail e ho ricevuto un {id}");
        }
    }
}