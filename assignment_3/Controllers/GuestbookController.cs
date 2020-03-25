using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using assignment_3.Data;
using assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace assignment_3.Controllers
{
    public class GuestbookController : Controller
    {
        
        private readonly DatabaseContext _db;
        
        public GuestbookController(DatabaseContext db)
        {
            
            _db = db;
            
        }
        //GET: Guestbooks
        [HttpGet]
        public IActionResult Index()
        {
            GuestbookViewModel vm = new GuestbookViewModel();

            vm.Guestbooks = _db.Posts.ToList();
            
            return View(vm);
        }
        
       
        
        
        [HttpPost]
        public IActionResult Index(Guestbook guestbook) //Valgt fra -name- variabler i viewet
        {
            
            if (ModelState.IsValid)
            {
                _db.Posts.Add(guestbook);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        
       
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}