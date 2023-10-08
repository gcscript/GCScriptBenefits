using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.Database.MongoDB.Models;

public class MOperator
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Uf { get; set; }

    public List<MOperatorContact>? Contact { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Url { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Notes { get; set; }

    [BsonRepresentation(BsonType.Boolean)]
    public bool GenerateOrder { get; set; }

    [BsonRepresentation(BsonType.Boolean)]
    public bool GenerateRegistration { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonRepresentation(BsonType.String)]
    public string CreatedBy { get; set; }
}