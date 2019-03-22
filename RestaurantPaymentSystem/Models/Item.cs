using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantPaymentSystem.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}