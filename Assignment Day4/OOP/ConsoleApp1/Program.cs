using OOP.Models;

//List<Vehicle> fleet = new();

//try
//{
//    fleet.Add(new Car("Toyota", "Corolla", 50));
//    fleet.Add(new Truck("Ford", "F-150", 80));
//    //fleet.Add(new Car("Honda", "Civic", 45));
//    fleet.Add(new Truck("Volvo", "FH", 100)); 
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error creating vehicle: {ex.Message}");
//}

//foreach (var vehicle in fleet)
//{
//    vehicle.Start();
//}
List<ITrackable> trackables = new()
{
    new Truck("Ford", "F-150", 80),
    new Truck("Volvo", "FH", 100)
};

foreach (var t in trackables)
{
    Console.WriteLine(t.GetLocation());
}
List<IMaintainable> maintenanceFleet = new()
{
    new Truck("Ford", "F-150", 80),
    new Truck("Volvo", "FH", 100)
};

foreach (var vehicle in maintenanceFleet)
{
    vehicle.ScheduleMaintenance();
}


Console.ReadLine();
