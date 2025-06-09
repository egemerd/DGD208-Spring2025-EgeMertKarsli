using System;
using System.Collections.Generic;
using System.Text.Json;

public class PetManager
{
	private static List<Pet> pets = new List<Pet>();

    public static void SaveGame(Player player)
    {
        var data = new GameData
        {
            Player = player,
            Pets = pets
        };

        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("save.json", json);
        Console.WriteLine("Game saved.");
    }

    public static Player? LoadGame()
    {
        if (!File.Exists("save.json"))
        {
            Console.WriteLine("No save file found.");
            return null;
        }

        string json = File.ReadAllText("save.json");
        GameData data = JsonSerializer.Deserialize<GameData>(json);

        foreach (var pet in pets)
        {
            pet.OnPetExpired += HandlePetExpired;
        }

        pets = data.Pets;
        Console.WriteLine("Game loaded.");
        return data.Player;
    }


    public static void AdoptPet(Pet pet)
    {
        pets.Add(pet);
        pet.OnPetExpired += HandlePetExpired;

        Console.WriteLine($"{pet.Name} the {pet.Species} has been adopted!");
        Console.ReadKey();
    }

    private static void HandlePetExpired(Pet pet)
    {
        pets.Remove(pet);
        Console.Write($"{pet.Name} the {pet.Species} has been removed due to all stats reaching zero.");
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

    
    public static void GiveMoney() 
    {
        
    }
    public static List<Pet> GetPets() => pets;

    

}
