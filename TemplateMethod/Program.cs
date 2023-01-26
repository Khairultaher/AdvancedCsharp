/*
 * The Template Method pattern is a design pattern used in software development to define the skeleton of an algorithm in a method,deferring some steps to subclasses. The Template Method pattern allows a common behavior to be shared among subclasses, while allowing subclasses to change the implementation of certain steps
 * 
 * Used to create a template method stub and defer some of the steps of implementation to the subclasses.
*/

CoffeeBrewing coffeeBrewing = new Espresso();
coffeeBrewing.Brew();

abstract class CoffeeBrewing
{
    public void Brew()
    {
        BoilWater();
        GrindBeans();
        AddCoffee();
        PourInCup();
        AddFlavor();
    }

    public abstract void GrindBeans();
    public abstract void AddCoffee();
    public abstract void AddFlavor();

    public void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    public void PourInCup()
    {
        Console.WriteLine("Pouring coffee in cup");
    }
}

class Espresso : CoffeeBrewing
{
    public override void GrindBeans()
    {
        Console.WriteLine("Grinding beans for Espresso");
    }

    public override void AddCoffee()
    {
        Console.WriteLine("Adding coffee for Espresso");
    }

    public override void AddFlavor()
    {
        Console.WriteLine("Adding flavor for Espresso");
    }
}

class FrenchPress : CoffeeBrewing
{
    public override void GrindBeans()
    {
        Console.WriteLine("Grinding beans for French Press");
    }

    public override void AddCoffee()
    {
        Console.WriteLine("Adding coffee for French Press");
    }

    public override void AddFlavor()
    {
        Console.WriteLine("Adding flavor for French Press");
    }
}

class Drip : CoffeeBrewing
{
    public override void GrindBeans()
    {
        Console.WriteLine("Grinding beans for Drip");
    }

    public override void AddCoffee()
    {
        Console.WriteLine("Adding coffee for Drip");
    }

    public override void AddFlavor()
    {
        Console.WriteLine("Adding flavor for Drip");
    }
}

