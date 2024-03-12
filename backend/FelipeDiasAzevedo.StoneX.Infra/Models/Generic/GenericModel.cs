using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FelipeDiasAzevedo.StoneX.Infra.Models.Generic;

public class GenericModel
{
    [BsonId]
    [JsonIgnore]
    public ObjectId BsonId { get; set; }

    public string Id => BsonId.ToString();
    
    public DateTime InsertDateTime => BsonId.CreationTime;
    
    [BsonElement(nameof(UpdateDateTime))]
    public DateTime UpdateDateTime { get; set; } = DateTime.UtcNow;
}