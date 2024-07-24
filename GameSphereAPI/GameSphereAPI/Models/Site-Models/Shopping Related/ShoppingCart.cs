using System.ComponentModel.DataAnnotations.Schema;

namespace GameSphereAPI.Models.Site_Models.Shopping_Related
{
    [Table("ShoppingCarts", Schema = "sho")]
    public class ShoppingCart
    {
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }
        public List<CartItem> Items { get; set; }
    }
}