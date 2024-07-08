using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TirelireWebApp.Models;

namespace TirelireWebApp.Controllers
{
	public class HomeController : Controller
	{
		//ILogger : journal pour enregistrer les infos important de l'app
		private readonly ILogger<HomeController> _logger;
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}




		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		
		public IActionResult Client()
		{
			return View();
		}
		public IActionResult Admin()
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
