using System.ComponentModel.DataAnnotations;

namespace DrinksMachine.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string DrinkName { get; set; }
        public int Price { get; set; }
        public string? Img { get; set; }
        public int Quantity { get; set; }
    }
}
