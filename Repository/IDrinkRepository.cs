using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using DrinksMachine.Models;
using DrinksMachine.Models.Data;

namespace DrinksMachine.Repositories
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> GetDrinks();
        Drink GetDrink(int id);
        void AddDrink(Drink drink);
        void UpdateDrink(Drink drink);
        void DeleteDrink(int id);
    }
}