using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
// add this line
using Microsoft.EntityFrameworkCore;
 
namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        // Set up a context service
        private MenuContext dbContext;
        // inject context service
        public HomeController(MenuContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var AllChefs = dbContext.Chefs.Include(c => c.Dishes).OrderByDescending(chef => chef.CreatedAt).ToList();
            return View("Index", AllChefs);
        }

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("new")]
        public IActionResult AddChef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NewChef");
        }

        [HttpGet("dishes")]
        public IActionResult ShowDishes()
        {
            var AllDishes = dbContext.Dishes.Include(d => d.Creator).OrderByDescending(dish => dish.CreatedAt).ToList();
            var AllChefs = dbContext.Chefs.OrderByDescending(chef => chef.CreatedAt).ToList();
            return View("Dishes", AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult AddDish()
        {
            var AllChefs = dbContext.Chefs.OrderByDescending(chef => chef.CreatedAt).ToList();
            @ViewBag.AllChefs = AllChefs;
            return View("NewDish");
        }

        [HttpPost("dishes/new")]
        public IActionResult AddDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("ShowDishes");
            }
            return View("NewDish");
        }
    }
}
