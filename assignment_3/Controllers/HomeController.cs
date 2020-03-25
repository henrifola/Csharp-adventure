using System.Diagnostics;
using System.Linq;
using assignment_3.Data;
using assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _db;
        
        public HomeController(ILogger<HomeController> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db;
            
        }
        
        [HttpGet]//Attributt, kan sette egenskaper på en funksjon eller variabel.
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(Guestbook guestbook) //Valgt fra -name- variabler i viewet
        {
            if (ModelState.IsValid)
            {
                _db.Posts.Add(guestbook);
                _db.SaveChanges();
            }

            return View(guestbook);
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
