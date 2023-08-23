using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.DataBase.Models;

public class MCompany
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string? Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ResponsibleGVT { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ResponsibleTI { get; set; }

    [BsonRepresentation(BsonType.Int32)]
    public int Margin { get; set; } = 3;

    [BsonRepresentation(BsonType.String)]
    public string? Observations { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Registered { get; set; } = DateTime.UtcNow;
}