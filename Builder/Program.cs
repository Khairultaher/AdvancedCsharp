/*
 * It is a creational pattern that separates the construction of a complex object from its representation, 
 * allowing the same construction process to create various representations.
 * 
 * Creating an object step by step and a method to finally get the object instance
 */

ComputerShop shop = new ComputerShop();
ComputerBuilder builder = new GamingComputerBuilder();
shop.SetComputerBuilder(builder);
shop.ConstructComputer();
Computer computer = shop.GetComputer();
Console.WriteLine(computer);


class Computer
{
    public string Processor { get; set; }
    public int Memory { get; set; }
    public int Storage { get; set; }
    public string GraphicsCard { get; set; }

    public override string ToString()
    {
        return $"Processor: {Processor}, Memory: {Memory}, Storage: {Storage}, GraphicsCard: {GraphicsCard}";
    }
}

abstract class ComputerBuilder
{
    protected Computer computer;

    public Computer GetComputer()
    {
        return computer;
    }

    public abstract void BuildProcessor();
    public abstract void BuildMemory();
    public abstract void BuildStorage();
    public abstract void BuildGraphicsCard();
}

class GamingComputerBuilder : ComputerBuilder
{
    public GamingComputerBuilder()
    {
        computer = new Computer();
    }

    public override void BuildProcessor()
    {
        computer.Processor = "i9-9900K";
    }

    public override void BuildMemory()
    {
        computer.Memory = 16;
    }

    public override void BuildStorage()
    {
        computer.Storage = 512;
    }

    public override void BuildGraphicsCard()
    {
        computer.GraphicsCard = "RTX 3090";
    }
}

class WorkComputerBuilder : ComputerBuilder
{
    public WorkComputerBuilder()
    {
        computer = new Computer();
    }

    public override void BuildProcessor()
    {
        computer.Processor = "i7-9700";
    }

    public override void BuildMemory()
    {
        computer.Memory = 8;
    }

    public override void BuildStorage()
    {
        computer.Storage = 256;
    }

    public override void BuildGraphicsCard()
    {
        computer.GraphicsCard = "GTX 1050";
    }

}

class ComputerShop
{
    private ComputerBuilder _computerBuilder;
    public void SetComputerBuilder(ComputerBuilder builder)
    {
        _computerBuilder = builder;
    }

    public Computer GetComputer()
    {
        return _computerBuilder.GetComputer();
    }

    public void ConstructComputer()
    {
        _computerBuilder.BuildProcessor();
        _computerBuilder.BuildMemory();
        _computerBuilder.BuildStorage();
        _computerBuilder.BuildGraphicsCard();
    }
}