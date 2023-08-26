using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DrinksMachine.Models;
using DrinksMachine.Repositories;

namespace DrinksMachine.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;

        public AdminController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Drink> drinks = _drinkRepository.GetDrinks();
            return View(drinks);
        }

        public IActionResult Create()
        {
            Drink drink = new Drink
            {
                DrinkName = "New Drink",
                Price = 0,
                Img = "",
                Quantity = 1
            };

            _drinkRepository.AddDrink(drink);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Drink drink = _drinkRepository.GetDrink(id);
            return View(drink);
        }

        [HttpPost]
        public IActionResult Edit(Drink drink)
        {
            _drinkRepository.UpdateDrink(drink);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _drinkRepository.DeleteDrink(id);
            return RedirectToAction("Index");
        }
    }
}