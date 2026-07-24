using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormsApp.Models
{

    //[Bind("Name", "Price")] bind etmenin farklı bir yöntemi.
    public class Product
    {
        [Display(Name ="Urun Id")]
        //[BindNever] //bind etmeyi engelliyoruz.
        public int ProductId { get; set; }

        [Display(Name ="Urun Adı")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Gerekli bir alan")]
        [Range(0, 100000)]
        [Display(Name ="Fiyat")]
        public decimal? Price { get; set; }

        [Display(Name ="Resim")]
        public string? Image { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        [Display(Name ="Category")]
        [Required]
        public int? CategoryId { get; set; }
    }
}