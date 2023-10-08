using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.Database.MongoDB.Models;

public class MOperatorContact
{

    [BsonRepresentation(BsonType.String)]
    public string? Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Phone { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Email { get; set; }
}