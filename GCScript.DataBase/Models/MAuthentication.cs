using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.DataBase.Models;

public class MAuthentication
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string? Message { get; set; }
}