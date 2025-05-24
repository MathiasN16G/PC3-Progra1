using Microsoft.AspNetCore.Mvc;
using PC3_Progra1.Data;
using PC3_Progra1.Models;
using System.Linq;

namespace PC3_Progra1.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Enviar(int postId, string sentimiento)
        {
            // Validar si ya existe feedback para ese post
            var existe = _context.Feedbacks.Any(f => f.PostId == postId);
            if (existe)
            {
                TempData["PostReaccionado"] = postId;
                TempData["Mensaje"] = "Ya registraste una reacción para esta publicación.";
                return RedirectToAction("Index", "Home");
            }

            var feedback = new Feedback
            {
                PostId = postId,
                Sentimiento = sentimiento
            };

            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();

            TempData["PostReaccionado"] = postId;
            TempData["Mensaje"] = "Gracias por tu reacción.";
            return RedirectToAction("Index", "Home");
        }

        // Acción para ver el historial de feedbacks
        public IActionResult Historial()
        {
            var historial = _context.Feedbacks
                .OrderBy(f => f.Id)
                .ToList();

            return View(historial);
        }
    }
}
