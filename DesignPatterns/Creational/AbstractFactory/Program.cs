/*
 * It is a creational pattern that provides an interface for creating families of related or dependent objects 
 * without specifying their concrete classes.
 * 
 * Allows us to create a Factory for factory classes.
 */

AbstractFactory factory1 = new ConcreteFactory1();
AbstractProductA productA1 = factory1.CreateProductA();
AbstractProductB productB1 = factory1.CreateProductB();
productA1.OperationA(); // Outputs "ConcreteProductA1 OperationA"
productB1.OperationB(); // Outputs "ConcreteProductB1 OperationB"

AbstractFactory factory2 = new ConcreteFactory2();
AbstractProductA productA2 = factory2.CreateProductA();
AbstractProductB productB2 = factory2.CreateProductB();
productA2.OperationA(); // Outputs "ConcreteProductA2 OperationA
productB2.OperationB(); // Outputs "ConcreteProductB2 OperationB"

abstract class AbstractFactory
{
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
}

class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public override AbstractProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public override AbstractProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}

abstract class AbstractProductA
{
    public abstract void OperationA();
}

abstract class AbstractProductB
{
    public abstract void OperationB();
}

class ConcreteProductA1 : AbstractProductA
{
    public override void OperationA()
    {
        Console.WriteLine("ConcreteProductA1 OperationA");
    }
}

class ConcreteProductA2 : AbstractProductA
{
    public override void OperationA()
    {
        Console.WriteLine("ConcreteProductA2 OperationA");
    }
}

class ConcreteProductB1 : AbstractProductB
{
    public override void OperationB()
    {
        Console.WriteLine("ConcreteProductB1 OperationB");
    }
}

class ConcreteProductB2 : AbstractProductB
{
    public override void OperationB()
    {
        Console.WriteLine("ConcreteProductB2 OperationB");
    }
}
