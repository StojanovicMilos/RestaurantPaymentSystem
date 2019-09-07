using System.ComponentModel;
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
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        public int Price { get; set; }

        public int SubcategoryId { get; set; }
    }
}