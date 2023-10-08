using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.Database.MongoDB.Models;

public class MUser
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Username { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Phone { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Email { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}