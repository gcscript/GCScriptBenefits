using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.DataBase.Models;

public class MOperator
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string? Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? UF { get; set; }

    public List<string>? Phone { get; set; }

    public List<string>? Email { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Url { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Observations { get; set; }

    [BsonRepresentation(BsonType.Boolean)]
    public bool GenerateOrder { get; set; }

    [BsonRepresentation(BsonType.Boolean)]
    public bool GenerateRegistration { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Registered { get; set; } = DateTime.UtcNow;
}