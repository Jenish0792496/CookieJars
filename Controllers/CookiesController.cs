using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCookieJars.Data;
using MvcCookieJars.Models;

namespace CookieJars.Controllers
{
    public class CookiesController : Controller
    {
        private readonly MvcCookieJarsContext _context;

        public CookiesController(MvcCookieJarsContext context)
        {
            _context = context;
        }

        // GET: Cookies
        public async Task<IActionResult> Index(string Ingridients, string searchString)
        {
            // Use LINQ to get list of genres.

            var cookies = from c in _context.Cookie
                          select c;

            IQueryable<string> genreQuery = from c in _context.Cookie
                                            orderby c.MainIngredents
                                            select c.MainIngredents;

            if (!String.IsNullOrEmpty(searchString))
            {
                cookies = cookies.Where(s => s.CookieName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(Ingridients))
            {
                cookies = cookies.Where(x => x.MainIngredents == Ingridients);
            }

            var cookiesGenereVM = new CookieGenereViewModel
            {
                MainIngredents = new SelectList(await genreQuery.Distinct().ToListAsync()),
                CookieName = await cookies.ToListAsync()
            };

            return View(cookiesGenereVM);
        }

        // GET: Cookies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // GET: Cookies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cookies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CookieName,MainIngredents,ReleaseDate,Pieces,Price,Rating")] Cookie cookie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cookie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cookie);
        }

        // GET: Cookies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie.FindAsync(id);
            if (cookie == null)
            {
                return NotFound();
            }
            return View(cookie);
        }

        // POST: Cookies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CookieName,MainIngredents,ReleaseDate,Pieces,Price,Rating")] Cookie cookie)
        {
            if (id != cookie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookieExists(cookie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cookie);
        }

        // GET: Cookies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // POST: Cookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cookie = await _context.Cookie.FindAsync(id);
            _context.Cookie.Remove(cookie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookieExists(int id)
        {
            return _context.Cookie.Any(e => e.Id == id);
        }
    }
}
