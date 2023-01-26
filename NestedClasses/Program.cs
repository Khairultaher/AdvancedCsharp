
Car myCar = new Car("Toyota", "Corolla", 2020);
myCar.EngineDetails.Horsepower = 140;
myCar.EngineDetails.Cylinders = 4;

Console.WriteLine("Make: " + myCar.Make); // "Toyota"
Console.WriteLine("Model: " + myCar.Model); // "Corolla"
Console.WriteLine("Year: " + myCar.Year); // 2020
Console.WriteLine("Horsepower: " + myCar.EngineDetails.Horsepower); // 140
Console.WriteLine("Cylinders: " + myCar.EngineDetails.Cylinders); // 4


public class Car
{
    private string make;
    private string model;
    private int year;
    private Engine engine;

    public Car(string make, string model, int year)
    {
        this.make = make;
        this.model = model;
        this.year = year;
        this.engine = new Engine();
    }

    public class Engine
    {
        private int horsepower;
        private int cylinders;

        public Engine()
        {
            horsepower = 0;
            cylinders = 0;
        }

        public int Horsepower
        {
            get { return horsepower; }
            set { horsepower = value; }
        }

        public int Cylinders
        {
            get { return cylinders; }
            set { cylinders = value; }
        }
    }

    public string Make
    {
        get { return make; }
    }

    public string Model
    {
        get { return model; }
    }

    public int Year
    {
        get { return year; }
    }

    public Engine EngineDetails
    {
        get { return engine; }
    }
}
