using System;

public class Pet
{
    public string Name { get; private set; }
    public PetSpecies Species { get; private set; }

    public int Sleep { get; set; } = 50;
	public int Happiness { get; set; } = 50;
    public int Hunger { get; set; } = 50;

    public Pet(string name, PetSpecies species)
    {
        Name = name;
        Species = species;
    }

    public void DecreaseStats(int decay)
    {
        Hunger = Math.Max(Hunger - decay, 0);
        Sleep = Math.Max(Sleep - decay, 0);
        Happiness = Math.Max(Happiness - decay, 0);
    }

    public void ShowStats()
    {
        Console.WriteLine($"{Name} the {Species} | Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Happiness}");
    }

    public bool IsAlive => Hunger > 0 && Sleep > 0 && Happiness > 0;

}
