namespace DrinksMachine.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public string CoinName { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public bool IsBlocked { get; set; }
    }
}
