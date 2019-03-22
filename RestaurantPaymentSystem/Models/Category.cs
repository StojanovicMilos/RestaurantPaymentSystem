using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RestaurantPaymentSystem.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public virtual List<Subcategory> Subcategories { get; set; }
    }
}