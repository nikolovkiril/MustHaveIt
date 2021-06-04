using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MustHaveIt.Data;
using MustHaveIt.Models;
using MustHaveIt.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MustHaveIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var viewModel = new IndexViewModel
            {
                Name = "KNx2",
                UsersCount = this.dbContext.Users.Count(),
                Year = DateTime.UtcNow.Year,
                DateTime = DateTime.Now.ToString("dddd"),
                Id = id,
                ProcesorsCount = Environment.ProcessorCount,
                Time = DateTime.Now.ToString("HH:mm")
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            var viewModel = new IndexViewModel
            {
                DateTime = DateTime.Now.ToString("dddd"),
                Time = DateTime.Now.ToString("HH:mm")
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
