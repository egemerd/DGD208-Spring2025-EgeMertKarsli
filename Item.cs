using System;

public class Item
{
    public string Name { get; }
    public string Description { get; }
    public int Cost { get; }

    public int HungerEffectPerTick { get; }
    public int SleepEffectPerTick { get; }
    public int HappinessEffectPerTick { get; }

    public int DurationInSeconds { get; }

    

    public async Task UseAsync(Pet pet)
    {
        Console.WriteLine($"{Name} is now being used on {pet.Name} for {DurationInSeconds} seconds.");

        for (int i = 0; i < DurationInSeconds; i++)
        {
            await Task.Delay(1000); 
            pet.Hunger += HungerEffectPerTick;
            pet.Sleep += SleepEffectPerTick;
            pet.Happiness += HappinessEffectPerTick;

            Console.WriteLine($"Tick {i + 1}: Applied effects to {pet.Name}.");
        }

        Console.WriteLine($"{Name} effect on {pet.Name} has ended.");
    }
}
