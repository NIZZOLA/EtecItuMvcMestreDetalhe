using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.AulaEtec.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.AulaEtec.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            DashBoardListModel lista = new DashBoardListModel();

            if (true)
            {
                DashBoardModel modelo = new DashBoardModel() { Data = DateTime.Now, Valor = 1500m };
                lista.Valores.Add(modelo);
            }

            return View(lista);
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
