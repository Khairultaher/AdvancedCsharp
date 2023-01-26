/*
 * It is a behavioral pattern that allows an object to alter its behavior when its internal state changes.
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
