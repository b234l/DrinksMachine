﻿using System;
using System.Data;

using DrinksMachine.Models;
using DrinksMachine.Models.Data;

namespace DrinksMachine.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly SqlConnection _connection;

        public DrinkRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Drink> GetDrinks()
        {
            var sql = "SELECT * FROM Drinks";
            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            var drinks = new List<Drink>();
            while (reader.Read())
            {
                drinks.Add(new Drink
                {
                    Id = reader["Id"].ToString(),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Price = reader["Price"].ToString(),
                });
            }

            return drinks;
        }

        public Drink GetDrink(int id)
        {
            var sql = "SELECT * FROM Drinks WHERE Id=@Id";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@Id", id);

            var reader = command.ExecuteReader();

            Drink drink = null;
            if (reader.Read())
            {
                drink = new Drink
                {
                    Id = reader["Id"].ToString(),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Price = reader["Price"].ToString(),
                };
            }

            return drink;
        }

        public void AddDrink(Drink drink)
        {
            var sql = "INSERT INTO Drinks (Name, Description, Price) VALUES (@Name, @Description, @Price)";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@Name", drink.Name);
            command.Parameters.AddWithValue("@Description", drink.Description);
            command.Parameters.AddWithValue("@Price", drink.Price);

            command.ExecuteNonQuery();
        }

        public void UpdateDrink(Drink drink)
        {
            var sql = "UPDATE Drinks SET Name=@Name, Description=@Description, Price=@Price WHERE Id=@Id";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@Name", drink.Name);
            command.Parameters.AddWithValue("@Description", drink.Description);
            command.Parameters.AddWithValue("@Price", drink.Price);
            command.Parameters.AddWithValue("@Id", drink.Id);

            command.ExecuteNonQuery();
        }

        public void DeleteDrink(int id)
        {
            var sql = "DELETE FROM Drinks WHERE Id=@Id";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}