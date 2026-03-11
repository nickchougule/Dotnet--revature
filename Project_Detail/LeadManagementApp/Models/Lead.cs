using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

class Lead
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId LeadId{get; set;}

    public string name{get; set;}

    public string email{get; set;}

    public string phone{get; set;}

    public string company{get;set;}

    public string position{get;set;}
    public string status{get;set;}

    public string source{get;set;}

    public string priority{get;set;}

    public string AssignedSalesRepId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}