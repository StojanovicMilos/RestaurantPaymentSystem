using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantPaymentSystem.Models
{
    public class Subcategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string SubcategoryName { get; set; }

        //[ForeignKey("CategoryName")]
        //public string CategoryName { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}