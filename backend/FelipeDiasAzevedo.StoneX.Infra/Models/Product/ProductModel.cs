using FelipeDiasAzevedo.StoneX.Infra.Models.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace FelipeDiasAzevedo.StoneX.Infra.Models.Product;

public class ProductModel : GenericModel
{
    [BsonElement(nameof(Name))]
    public string Name { get; set; }

    [BsonElement(nameof(StockKeepingUnit))]
    public string StockKeepingUnit { get; set; }

    [BsonElement(nameof(Price))]
    public decimal Price { get; set; }

    [BsonElement(nameof(StockCount))]
    public long StockCount { get; set; }
}