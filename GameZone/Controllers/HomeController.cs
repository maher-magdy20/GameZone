using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
	public class HomeController : Controller
	{
		private readonly IGemesServise _gemesServise;

		public HomeController(IGemesServise gemesServise)
		{
            _gemesServise = gemesServise;
		}

		public IActionResult Index()
		{
			var games = _gemesServise.GetAll();
			return View(games);
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