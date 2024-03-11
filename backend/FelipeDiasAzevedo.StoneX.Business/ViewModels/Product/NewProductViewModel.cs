using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace FelipeDiasAzevedo.StoneX.Business.ViewModels.Product;

public class NewProductViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [StringLength(12, MinimumLength = 6)]
    public string StockKeepingUnit { get; set; }

    [Required]
    [Range(0d, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [Range(0, long.MaxValue)]
    public long StockCount { get; set; }
}