using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CandyShop.Controllers
{
    [ApiController]
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult ShowCandys()
        {
            var candys = _context.Candys.Include(s => s.Category).ToList();
            return View(candys);
        }

        [HttpGet]
        [Route("/add")]
        public IActionResult AddCandy()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        [Route("/add")]
        public IActionResult AddCandy([FromForm] Candy candy)
        {
            if (ModelState.IsValid)
            {
                _context.Candys.Add(candy);
                _context.SaveChanges();
                return RedirectToAction(nameof(ShowCandys));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(candy);
        }

        [HttpGet]
        [Route("/edit/{id}")]
        public IActionResult EditCandy(long id)
        {
            var candy = _context.Candys.Find(id);
            if (candy == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(candy);
        }

        [HttpPost]
        [Route("/edit/{id}")]
        public IActionResult EditCandy(int id, [FromForm] Candy candy)
        {
            if (id != candy.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                candy.Category = _context.Categories.Find(candy.CategoryId);

                _context.Entry(candy).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(ShowCandys));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(candy);
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public IActionResult DeleteShoe(int id)
        {
            var shoe = _context.Candys.Include(s => s.Category).FirstOrDefault(s => s.Id == id);
            if (shoe == null)
            {
                return NotFound();
            }

            var category = shoe.Category;

            _context.Candys.Remove(shoe);
            _context.SaveChanges();



            if (!_context.Candys.Any(s => s.CategoryId == category.Id))
            {
                _context.Categories.Remove(category);
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(ShowCandys));
        }
    }
}
