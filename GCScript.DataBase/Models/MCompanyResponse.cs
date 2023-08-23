using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GCScript.DataBase.Models;

public class MCompanyResponse
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
}