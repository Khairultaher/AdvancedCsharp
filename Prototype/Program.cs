/*
 * It is a creational pattern that creates new objects by copying existing objects, which serves as a prototype.
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

