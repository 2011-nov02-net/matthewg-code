using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HelloMvcTemplate.Controllers {
    public class HelloWorldController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Welcome(string name, int id = 1) {
            ViewData["Message"] = "Hello " + name;
            ViewData["ID"] = id;
            return View();
        }
    }
}
