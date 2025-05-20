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
        
        Console.WriteLine("=== All Pets ===");
        foreach (var pet in pets)
        {
            pet.ShowStats();
        }
        
    }

    public static void TickStats(Player player)
    {
        int decay = player.ApplyStatDecay(2);
        foreach (var pet in pets)
        {
            pet.DecreaseStats(decay);
        }
    }

    public static void ClearPets()
    {
        pets.Clear();
        
    }

    

    public static List<Pet> GetPets() => pets;

    

}
