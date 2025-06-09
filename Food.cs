using System;
using System.Collections.Generic;

public class Food
{
    public string name { get; set; }
    public int hungerEffect { get; set; }
    public int sleepEffect { get; set; }
    public int happinessEffect { get; set; }

    public Food(string Name, int HungerEffect, int SleepEffect, int HappinessEffect)
    {
        name = Name;
        hungerEffect = HungerEffect;
        sleepEffect = SleepEffect;
        happinessEffect = HappinessEffect;
    }

    private static List<Food> foodItems = new List<Food>
    {
        new Food("Apple", 10, 6, -7),
        new Food("Banana", 8, -4, 2),
        new Food("Watermelon", -3, 7, 4)
    };

    public void Feed(Pet pet)
    {
        pet.Hunger += hungerEffect;
        pet.Sleep += sleepEffect;
        pet.Happiness += happinessEffect;

        Console.WriteLine($"{name} effect is used on {pet.Name}.");
    }

    public static void FeedPetMenu()
    {
        var pets = PetManager.GetPets();
        if (pets.Count == 0)
        {
            Console.WriteLine("You have no pets.");
            return;
        }

        Console.WriteLine("Choose a pet to feed:");
        for (int i = 0; i < pets.Count; i++)
            Console.WriteLine($"{i + 1}. {pets[i].Name}");

        if (int.TryParse(Console.ReadLine(), out int petIndex) && petIndex > 0 && petIndex <= pets.Count)
        {
            var selectedPet = pets[petIndex - 1];

            Console.WriteLine("Choose a food item:");
            for (int i = 0; i < foodItems.Count; i++)
            {
                var food = foodItems[i];
                Console.WriteLine($"{i + 1}. {food.name} ({FormatEffect("Hunger", food.hungerEffect)}, {FormatEffect("Sleep", food.sleepEffect)}, {FormatEffect("Happiness", food.happinessEffect)})");
            }

            if (int.TryParse(Console.ReadLine(), out int foodIndex) && foodIndex > 0 && foodIndex <= foodItems.Count)
            {
                var selectedFood = foodItems[foodIndex - 1];
                selectedFood.Feed(selectedPet);
            }
        }

        Console.ReadKey();
    }

    private static string FormatEffect(string label, int value)
    {
        string sign = value > 0 ? "+" : value < 0 ? "-" : "±";
        return $"{label} {sign}{Math.Abs(value)}";
    }
}
