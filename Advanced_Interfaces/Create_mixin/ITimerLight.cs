namespace Advanced_Interfaces.Create_mixin;

public interface ITimerLight : ILight
{
    //Task TurnOnFor(int duration);
    public async Task TurnOnFor(int duration)
    {
        Console.WriteLine("Using the default interface method for the ITimerLight.TurnOnFor.");
        SwitchOn();
        await Task.Delay(duration);
        Console.ResetColor();
        Console.WriteLine("Completed ITimerLight.TurnOnFor sequence.");
    }
}