namespace car
{
    public class Cars
    {
        public string Engine { get; set; }
        public string Model { get; set; }
        public string color { get; set; }
    
        public Cars(string engine, string model, string color)
        {
        this.Engine = engine;
        this.Model = model;
        this.color = color;
        }
        
        public void DisplayCarInfo(Cars car)
        {
            Console.WriteLine($"Engine: {car.Engine}, Model: {car.Model}, Color: {car.color}");
        }
    }
}
namespace ExtensionMethodsPractice
{
   using car;
    public static class CarExtensions
    {
        public static void PaintCar(this Cars car, string newColor)
        {
            car.color = newColor;
            Console.WriteLine($"The car has been painted {newColor}.");
        }
    } 
}



