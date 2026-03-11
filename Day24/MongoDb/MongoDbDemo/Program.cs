using MongoDB.Driver;

class Program
{
    static void Main()
    {
        // Connection string
        var connectionString = "mongodb://localhost:27017";

        // Create client
        var client = new MongoClient(connectionString);

        // Access database
        var database = client.GetDatabase("LeadManagement");

        // Access collection
        var collection = database.GetCollection<Lead>("Leads");

        // Create new lead
        var lead = new Lead
        {
            Name = "Soham",
            Email = "Soham@test.com",
            Status = "New"
        };

        // Insert into MongoDB
        collection.InsertOne(lead);

        Console.WriteLine("Lead inserted successfully!");
    }
}