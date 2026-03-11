using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var connectionString = "mongodb://localhost:27017";

var client = new MongoClient(connectionString);

var db = client.GetDatabase("LeadManagementDb");

Console.WriteLine("Connected to MongoDB");

var leadCollection= db.GetCollection<Lead>("leads");


app.MapPost("/api/leads", async (Lead lead) =>
{
    lead.CreatedDate = DateTime.UtcNow;
    lead.ModifiedDate = DateTime.UtcNow;

    await leadCollection.InsertOneAsync(lead);

    return Results.Ok(lead);
});


app.MapGet("/api/leads", async () =>
{
    var leads = await leadCollection.Find(_ => true).ToListAsync();
    return Results.Ok(leads);
});



var newLead= new Lead
{
    name = "Nikhil",
    email = "Nikhil@gmail.com",
    phone = "8999150297",
    company = "revature",
    position = "Software Engineer",
    status = "New",
    source = "Website",
    priority = "High",
    AssignedSalesRepId = "SR101",
    CreatedDate = DateTime.UtcNow,
    ModifiedDate = DateTime.UtcNow
};


await leadCollection.InsertOneAsync(newLead);

Console.WriteLine("Inserted new Lead:"+newLead.name);

var leads = await leadCollection.Find(_ => true).ToListAsync();


Console.WriteLine("Customers in database:");
foreach (var lead in leads)
{
    Console.WriteLine($"- {lead.name} ({lead.email})");
}


app.MapPut("/api/leads/{id}", async (string id, Lead updatedLead) =>
{
    var objectId = new ObjectId(id);

    var filter = Builders<Lead>.Filter.Eq(l => l.LeadId, objectId);

    var update = Builders<Lead>.Update
        .Set(l => l.name, updatedLead.name)
        .Set(l => l.email, updatedLead.email)
        .Set(l => l.phone, updatedLead.phone)
        .Set(l => l.company, updatedLead.company)
        .Set(l => l.position, updatedLead.position)
        .Set(l => l.status, updatedLead.status)
        .Set(l => l.source, updatedLead.source)
        .Set(l => l.priority, updatedLead.priority)
        .Set(l => l.AssignedSalesRepId, updatedLead.AssignedSalesRepId)
        .Set(l => l.ModifiedDate, DateTime.UtcNow);

    await leadCollection.UpdateOneAsync(filter, update);

    return Results.Ok("Lead Updated");
});


app.MapDelete("/api/leads/{id}", async (string id) =>
{
    var objectId = new ObjectId(id);

    var filter = Builders<Lead>.Filter.Eq(l => l.LeadId, objectId);

    await leadCollection.DeleteOneAsync(filter);

    return Results.Ok("Lead Deleted");
});


app.Run();  
