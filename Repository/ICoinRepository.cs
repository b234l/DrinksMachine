using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using DrinksMachine.Models;
using DrinksMachine.Models.Data;

namespace DrinksMachine.Repositories
{
    public interface ICoinRepository
    {
        Coin GetCoinById(int id);
        IEnumerable<Coin> GetCoins();
        void AddCoin(Coin coin);
        void SubtractCoin(int id);
        void BlockCoin(int id);
        void UnblockCoin(int id);
    }
}