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
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    name = "Contact request",
                    strength = "90",
                    note = model.Message,
                    organization = new
                    {
                        name = model.CompanyName
                    },
                    person = new
                    {
                        firstName = model.PersonFirstName,
                        lastName = model.PersonLastName
                    }
                }, Formatting.Indented);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://api.staging.lime-go.com/v1/signal";
                var apiKey = "96173b00-731c-4266-bdd9-708e0aea2f63";
                var httpClient = new HttpClient();
                var response = httpClient.PostAsync($"{url}?{apiKey}", content);
                if (response.Result.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    ViewData["Message"] = "Thank you for contacting us!";
                }
                else
                {
                    ModelState.Clear();
                    ViewData["Message"] = $"{response.Result.StatusCode} - {response.Result.ReasonPhrase}";
                }
            }
            else
            {
                ViewData["Message"] = null;
            }

            ViewData["Title"] = "Another contact form";

            return View();
        }

        public IActionResult AnotherContact()
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
