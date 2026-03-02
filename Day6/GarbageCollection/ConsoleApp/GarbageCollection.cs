namespace Day6
{
    class GarbageCollection
{
    public string name{get;set;}


    public GarbageCollection(string name)
    {
        this.name=name;
        Console.WriteLine($"{name} Created Successfully");
    }

    ~GarbageCollection()
    {
        Console.WriteLine($"{name} Destroyed");
    }
}
}

