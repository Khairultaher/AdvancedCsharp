/*
 * It is a behavioral pattern that allows objects to communicate without knowing each other's identities, 
 * reducing the dependencies between objects.
*/

IMediator mediator = new ATCMediator();
Airplane airplane1 = new Airplane(mediator);
Airplane airplane2 = new Airplane(mediator);
Helicopter helicopter1 = new Helicopter(mediator);
mediator.Register(airplane1);
mediator.Register(airplane2);
mediator.Register(helicopter1);

airplane1.Send("Hello from Airplane 1");

interface IMediator
{
    void Register(Aircraft helicopter1);
    void Send(string message, Aircraft sender);
}

abstract class Aircraft
{
    protected IMediator _mediator;
    public Aircraft(IMediator mediator)
    {
        _mediator = mediator;
    }
    public void Send(string message)
    {
        _mediator.Send(message, this);
    }
    public abstract void Receive(string message);
}

class Airplane : Aircraft
{
    public Airplane(IMediator mediator) : base(mediator) { }
    public override void Receive(string message)
    {
        Console.WriteLine("Airplane received: " + message);
    }
}

class Helicopter : Aircraft
{
    public Helicopter(IMediator mediator) : base(mediator) { }
    public override void Receive(string message)
    {
        Console.WriteLine("Helicopter received: " + message);
    }
}

class ATCMediator : IMediator
{
    private List<Aircraft> _aircrafts;
    public ATCMediator()
    {
        _aircrafts = new List<Aircraft>();
    }
    public void Register(Aircraft aircraft)
    {
        _aircrafts.Add(aircraft);
    }
    public void Send(string message, Aircraft sender)
    {
        _aircrafts.Where(a => a != sender).ToList().ForEach(a => a.Receive(message));
    }
}

