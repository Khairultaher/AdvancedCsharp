/*
 * It is a behavioral pattern that allows an object to alter its behavior when its internal state changes.
 * 
 * The State pattern is a design pattern used in software development to allow an object to change its behavior based on its internal state, without changing its class. The State pattern defines a set of related classes that represent the different states of an object, and a "context" class that holds a reference to the current state object. The context class forwards requests to the current state object, which handles the request based on its current state.
 * 
 * State design pattern is used when an Object change it’s behavior based on it’s internal state.
*/

TrafficLight trafficLight = new TrafficLight(new GreenLight());
trafficLight.Change();
trafficLight.Change();
trafficLight.Change();


interface ITrafficLightState
{
    void Change(TrafficLight trafficLight);
}

class TrafficLight
{
    public ITrafficLightState _state;
    public TrafficLight(ITrafficLightState state)
    {
        _state = state;
    }
    public void Change()
    {
        _state.Change(this);
    }
}

class GreenLight : ITrafficLightState
{
    public void Change(TrafficLight trafficLight)
    {
        Console.WriteLine("Green light");
        trafficLight._state = new YellowLight();
    }
}

class YellowLight : ITrafficLightState
{
    public void Change(TrafficLight trafficLight)
    {
        Console.WriteLine("Yellow light");
        trafficLight._state = new RedLight();
    }
}

class RedLight : ITrafficLightState
{
    public void Change(TrafficLight trafficLight)
    {
        Console.WriteLine("Red light");
        trafficLight._state = new GreenLight();
    }
}
