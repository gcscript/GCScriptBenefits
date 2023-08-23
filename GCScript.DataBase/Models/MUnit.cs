using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.DataBase.Models;

public class MUnit
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string? Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Username { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Password { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? CNPJ { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId CompanyId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId OperatorId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Observations { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Registered { get; set; } = DateTime.UtcNow;
}