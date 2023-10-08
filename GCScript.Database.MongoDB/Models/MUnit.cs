using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.Database.MongoDB.Models;

public class MUnit
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Username { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Password { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Cnpj { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Uf { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Operator { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Company { get; set; }

    //[BsonRepresentation(BsonType.String)]
    //public string? Notes { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonRepresentation(BsonType.String)]
    public string CreatedBy { get; set; }
}