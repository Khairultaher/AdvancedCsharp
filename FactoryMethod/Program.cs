
/*
 * It is a creational pattern that provides an interface for creating objects in a superclass, 
 * but allows subclasses to alter the type of objects that will be created.
*/

VehicleFactory factory = new ConcreteVehicleFactory();
IVehicle car = factory.CreateVehicle("car");
car.StartEngine();
IVehicle motorcycle = factory.CreateVehicle("motorcycle");
motorcycle.StartEngine();
IVehicle bicycle = factory.CreateVehicle("bicycle");
bicycle.StartEngine();

abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle(string type);
}

class ConcreteVehicleFactory : VehicleFactory
{
    public override IVehicle CreateVehicle(string type)
    {
        switch (type)
        {
            case "car":
                return new Car();
            case "motorcycle":
                return new Motorcycle();
            case "bicycle":
                return new Bicycle();
            default:
                throw new ArgumentException("Invalid vehicle type.");
        }
    }
}

interface IVehicle
{
    int Wheels { get; }
    int Seats { get; }
    void StartEngine();
}

class Car : IVehicle
{
    public int Wheels => 4;
    public int Seats => 5;
    public void StartEngine() => Console.WriteLine("Vroom!");
}

class Motorcycle : IVehicle
{
    public int Wheels => 2;
    public int Seats => 2;
    public void StartEngine() => Console.WriteLine("Vroom!");
}

class Bicycle : IVehicle
{
    public int Wheels => 2;
    public int Seats => 1;
    public void StartEngine() => throw new InvalidOperationException("Bicycles don't have an engine!");
}





