/*
 * It is a behavioral pattern that encapsulates a request as an object, allowing the request 
 * to be passed as a method argument, delayed or logged, and supports undo/redo.
 * 
 * Command Pattern is used to implement lose coupling in a request-response model.
*/

Light light = new Light();
ICommand turnOnCommand = new TurnOnCommand(light);
ICommand turnOffCommand = new TurnOffCommand(light);
Switch lightSwitch = new Switch(turnOnCommand, turnOffCommand);
lightSwitch.On();
lightSwitch.Off();

interface ICommand
{
    void Execute();
}

class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is off");
    }
}

class TurnOnCommand : ICommand
{
    private Light _light;
    public TurnOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

class TurnOffCommand : ICommand
{
    private Light _light;
    public TurnOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}

class Switch
{
    private ICommand _onCommand;
    private ICommand _offCommand;

    public Switch(ICommand onCommand, ICommand offCommand)
    {
        _onCommand = onCommand;
        _offCommand = offCommand;
    }

    public void On()
    {
        _onCommand.Execute();
    }

    public void Off()
    {
        _offCommand.Execute();
    }
}

