using GameSphereAPI.Models.Site_Models.Game_Related;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.Site_Models.Shopping_Related
{
    [Table("CartItems", Schema = "sho")]
    public class CartItem
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public Game Game { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}