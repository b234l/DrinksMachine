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
    public class DrinksMachineController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinksMachineController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public IActionResult Index()
        {
            var drinks = _drinkRepository.GetDrinks();
            return View(drinks);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var drink = _drinkRepository.GetDrinkById(id);
            if (drink == null)
            {
                return RedirectToAction("Index");
            }

            return View(drink);
        }

        public IActionResult Delete(int id)
        {
            var drink = _drinkRepository.GetDrinkById(id);
            if (drink == null)
            {
                return RedirectToAction("Index");
            }

            _drinkRepository.Delete(drink);
            _drinkRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return View(drink);
            }

            _drinkRepository.Add(drink);
            _drinkRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Drink drink)
        {
            if (!ModelState.IsValid)
            {
                return View(drink);
            }

            _drinkRepository.Update(drink);
            _drinkRepository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
