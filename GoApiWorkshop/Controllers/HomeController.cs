using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GoApiWorkshop.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace GoApiWorkshop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact us!";

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            ViewData["Title"] = "Contact us!";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
