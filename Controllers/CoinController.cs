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
    public class CoinController : Controller
    {
        private readonly ICoinRepository _coinRepository;

        public CoinController(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public IActionResult Index()
        {
            var coins = _coinRepository.GetCoins();
            return View(coins);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var coin = _coinRepository.GetCoinById(id);
            if (coin == null)
            {
                return RedirectToAction("Index");
            }

            return View(coin);
        }

        public IActionResult Delete(int id)
        {
            var coin = _coinRepository.GetCoinById(id);
            if (coin == null)
            {
                return RedirectToAction("Index");
            }

            _coinRepository.Delete(coin);
            _coinRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(Coin coin)
        {
            if (!ModelState.IsValid)
            {
                return View(coin);
            }

            _coinRepository.Add(coin);
            _coinRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Coin coin)
        {
            if (!ModelState.IsValid)
            {
                return View(coin);
            }

            _coinRepository.Update(coin);
            _coinRepository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}