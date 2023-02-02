/*
 * The Prototype pattern is a creational design pattern that allows an object to create a copy of itself, 
 * rather than creating a new instance from scratch. This can be useful when creating objects that are 
 * expensive to create, such as large data structures or complex algorithms.
 * 
 * Creating a new object instance from another similar instance and then modify according to our requirements.
 */

Prototype prototypeA = new ConcretePrototypeA("1", "A");
Prototype prototypeB = new ConcretePrototypeB("2","B");
Prototype cloneA = prototypeA.Clone();
Prototype cloneB = prototypeB.Clone();

abstract class Prototype
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Prototype(string id, string name)
    {
        this.Id = id;
        Name = name;
    }
    public abstract Prototype Clone();
}

class ConcretePrototypeA : Prototype
{
    public ConcretePrototypeA(string id, string name) : base(id, name) { }
    public override Prototype Clone()
    {
        //shallow copy, with same reference/memory location
        return (Prototype)this.MemberwiseClone();

        //deep copy, with new reference/memory location
        //return new ConcretePrototypeA(this.Id, this.Name);
    }
}

class ConcretePrototypeB : Prototype
{
    public ConcretePrototypeB(string id, string name) : base(id, name) { }
    public override Prototype Clone()
    {
        //return (Prototype)this.MemberwiseClone();
        return new ConcretePrototypeB(this.Id, this.Name);
    }
}

