using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DrinksMachine.Models.Data;
using DrinksMachine.Models;

namespace DrinksMachine.Services
{
    public class DrinkService
    {
        private readonly DrinkDBContext _dbContext;

        public DrinkService(DrinkDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Drink> GetDrinks()
        {
            return _dbContext.Drinks.ToList();
        }

        public void AddDrink(Drink drink)
        {
            _dbContext.Drinks.Add(drink);
            _dbContext.SaveChanges();
        }

        public void EditDrink(Drink drink)
        {
            _dbContext.Entry(drink).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteDrink(int id)
        {
            var drink = _dbContext.Drinks.Find(id);

            if (drink == null)
            {
                throw new Exceptions.NotFoundException();
            }

            _dbContext.Drinks.Remove(drink);
            _dbContext.SaveChanges();
        }
    }
}
