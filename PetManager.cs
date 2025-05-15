using System;
using System.Collections.Generic;

public class PetManager
{
	private static List<Pet> pets = new List<Pet>();

    public static void AdoptPet(Pet pet)
    {
        pets.Add(pet);
        Console.WriteLine($"{pet.Name} the {pet.Species} has been adopted!");
        Console.ReadKey();
    }

    public static void ShowAllPets()
    {
        Console.Clear();
        Console.WriteLine("=== All Pets ===");
        foreach (var pet in pets)
        {
            pet.ShowStats();
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void TickStats(Player player)
    {
        int decay = player.ApplyStatDecay(1);
        foreach (var pet in pets)
        {
            pet.DecreaseStats(decay);
        }
    }

    public static List<Pet> GetPets() => pets;



}
