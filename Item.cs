using System;
using System.Threading.Tasks;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }

    
    public int Hunger { get; set; }
    public int Sleep { get; set; }
    public int Happiness { get; set; }

    public string Rareness { get; set; }

    public int Duration { get; set; }

    public Item() { }


    public async Task UseAsync(Pet pet, Player player)
    {
        int adjustedDuration = player.ApplyItemDuration(Duration);
        Console.WriteLine($"{Name} is now being used on {pet.Name} for {adjustedDuration} seconds.");

        for (int i = 0; i < adjustedDuration; i++)
        {
            await Task.Delay(1000);
            pet.Hunger += Hunger;
            pet.Sleep += Sleep;
            pet.Happiness += Happiness;

            Console.WriteLine($"Tick {i + 1}: Applied effects to {pet.Name}.");
        }

        Console.WriteLine($"{Name} effect on {pet.Name} has ended.");
    }
}
