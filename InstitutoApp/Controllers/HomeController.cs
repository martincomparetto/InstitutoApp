using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InstitutoApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace InstitutoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("api.giphy.com/v1/gifs/search?q=Rick and Morty&limit=10&api_key=HYPCfkyJ28MrTAFdG8as9SgE0COs7mWd"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
