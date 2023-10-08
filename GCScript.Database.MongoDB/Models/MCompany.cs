using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.Database.MongoDB.Models;

public class MCompany
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }

    public List<MCompanyContact>? Contact { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ImageUrl { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string ResponsibleGVT { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string ResponsibleTI { get; set; }

    [BsonRepresentation(BsonType.Int32)]
    public int Margin { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Notes { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonRepresentation(BsonType.String)]
    public string CreatedBy { get; set; }
}