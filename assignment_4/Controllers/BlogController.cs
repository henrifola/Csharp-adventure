using System;
using System.Linq;
using System.Threading.Tasks;
using assignment_4.Data;
using assignment_4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace assignment_4.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<Account> _um;
        //private RoleManager<Account> _rm;

        public BlogController(ApplicationDbContext db, UserManager<Account> um)
        {
            _db = db;
            _um = um;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            //var user = _um.GetUserAsync(User).Result;
            var vm = new PostViewModel();
            vm.Posts = _db.Posts.Include(post => post.Account)
                .OrderByDescending(p => p.Time)
                .ToList();
            return View(vm);
        }

        [HttpGet, Authorize]
        public IActionResult Add()
        {
            ViewData["Id"] = new SelectList(_db.Accounts, "Id", "Nickname");
            return View();
        }
        
        
        [HttpPost, Authorize]
        public async Task<IActionResult> Add([Bind("PostId,Title,Summary,Content,AccountId")] Post post)
        {

            if (ModelState.IsValid)
            {
                var user = _um.GetUserAsync(User).Result;
                post.Account = user;
                post.AccountId = user.Id;
                post.Time = DateTime.Now;
                _db.Posts.Add(post);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_db.Accounts, "Id", "Nickname");
            return View(post);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            
            var post = await _db.Posts.FindAsync(id);
            
            if (post == null)
                return NotFound();
            
            var user = _um.GetUserAsync(User).Result;
            
            if (post.AccountId != user.Id)
                return RedirectToAction(nameof(Index));
            
            var idData = new SelectList(_db.Accounts, "Id", "Nickname", post.AccountId);
            ViewData["Id"] = idData;
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost, Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Summary,Content,AccountId")] Post post)
        {
            if (id != post.PostId)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                try
                {
                    post.Account = _um.GetUserAsync(User).Result;
                    post.Time = DateTime.Now;
                    _db.Update(post);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            var idData = new SelectList(_db.Accounts, "Id", "Nickname", post.AccountId);
            ViewData["Id"] = idData;
            return View(post);
        }
        
        private bool PostExists(int id)
        {
            return _db.Posts.Any(e => e.PostId == id);
        }
        
    }
}