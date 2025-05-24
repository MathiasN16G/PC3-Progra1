using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PC3_Progra1.Services;
using PC3_Progra1.Models;

namespace PC3_Progra1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _apiService;

        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        // Mostrar todos los posts enriquecidos con autor y comentarios
        public async Task<IActionResult> Index()
        {
            var postsCompletos = await _apiService.GetPostsCompletosAsync();
            return View(postsCompletos);
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
