using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Lead
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Status { get; set; }
}