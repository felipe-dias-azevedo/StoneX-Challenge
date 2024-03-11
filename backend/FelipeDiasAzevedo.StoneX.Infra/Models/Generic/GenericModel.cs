using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FelipeDiasAzevedo.StoneX.Infra.Models.Generic;

public class GenericModel
{
    [BsonId] 
    public ObjectId Id { get; set; }

    [BsonElement(nameof(InsertDateTime))] 
    public DateTime InsertDateTime { get; set; } = DateTime.UtcNow;
    
    [BsonElement(nameof(UpdateDateTime))]
    public DateTime UpdateDateTime { get; set; } = DateTime.UtcNow;
}