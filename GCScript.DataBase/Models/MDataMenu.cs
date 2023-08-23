using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.DataBase.Models;

public class MDataMenu
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonRepresentation(BsonType.String)]
    public string? UF { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Operator { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Company { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Unit { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId UnitId { get; set; }
}