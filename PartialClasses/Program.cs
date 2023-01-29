

Car car =new Car();
Console.WriteLine(car.add(1));
Console.WriteLine(car.add(1, 1));

// File: Car.cs
public partial class Car
{
    private string make;
    private string model;
    private int year;

    public int add(int a)
    {
        return 1;
    }
    public string add(int a, int b)
    {
        return "aaaa";
    }
    public Car(string make, string model, int year)
    {
        this.make = make;
        this.model = model;
        this.year = year;
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
}

// File: CarDetails.cs
public partial class Car
{
    private int horsepower;
    private int cylinders;

    public Car()
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

