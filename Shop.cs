using System;
using System.Collections.Generic;

public static class Shop
{
    public static List<Item> AvailableItems = new List<Item>
    {
        new Item
        {
            Name = "Treat",
            Description = "Restores hunger",
            Cost = 5,
            Hunger = 10,
            Sleep = 0,
            Happiness = 0,
            Rareness = "Uncommon",
            Duration = 2
        },
        new Item
        {
            Name = "Toy",
            Description = "Increases happiness",
            Cost = 15,
            Hunger = 0,
            Sleep = 0,
            Happiness = 20,
            Rareness = "Uncommon",
            Duration = 3
        },
        new Item
        {
            Name = "Bed",
            Description = "Improves sleep",
            Cost = 10,
            Hunger = 0,
            Sleep = 25,
            Happiness = 0,
            Rareness = "Uncommon",
            Duration = 3
        },
        new Item
        {
            Name = "Blanket",
            Description = "Helps your pet rest better",
            Cost = 12,
            Hunger = 0,
            Sleep = 20,
            Happiness = 5,
            Rareness = "Common",
            Duration = 2
        },
        new Item
        {
            Name = "Snack Bar",
            Description = "Quick snack to ease hunger slightly",
            Cost = 3,
            Hunger = 5,
            Sleep = 0,
            Happiness = 0,
            Rareness = "Common",
            Duration = 1
        },


        new Item
        {
            Name = "Golden Fish",
            Description = "A luxurious treat that greatly reduces hunger",
            Cost = 40,
            Hunger = 60,
            Sleep = 0,
            Happiness = 50,
            Rareness = "Rare",
            Duration = 3
        },
        new Item
        {
            Name = "Rubber Ball",
            Description = "A fun toy that improves happiness over time",
            Cost = 18,
            Hunger = 0,
            Sleep = 0,
            Happiness = 40,
            Rareness = "Common",
            Duration = 4
        },
        new Item
        {
            Name = "Dream Cushion",
            Description = "Gently improves sleep and happiness",
            Cost = 25,
            Hunger = 0,
            Sleep = 50,
            Happiness = 30,
            Rareness = "Rare",
            Duration = 5
        },
        new Item
        {
            Name = "Magic Biscuit",
            Description = "Slightly improves all stats at once",
            Cost = 35,
            Hunger = 20,
            Sleep = 15,
            Happiness = 15,
            Rareness = "Epic",
            Duration = 4
        },
        new Item
        {
            Name = "Chocolate Bone",
            Description = "A tasty bone that boosts happiness and hunger",
            Cost = 30,
            Hunger = 45,
            Sleep = 0,
            Happiness = 50,
            Rareness = "Rare",
            Duration = 5
        },
        new Item
        {
            Name = "Energy Drink",
            Description = "Boosts sleep and happiness instantly",
            Cost = 26,
            Hunger = 0,
            Sleep = 35,
            Happiness = 25,
            Rareness = "Uncommon",
            Duration = 2
        },
        new Item
        {
            Name = "Mega Meal",
            Description = "Fills your pet completely",
            Cost = 60,
            Hunger = 100,
            Sleep = 0,
            Happiness = 0,
            Rareness = "Rare",
            Duration = 5
        },
        new Item
        {
            Name = "Şıppıdık",
            Description = "A legendary item that makes the pet unrecognizable with the power of camera lens",
            Cost = 90,
            Hunger = 100,
            Sleep = 100,
            Happiness = 100,
            Rareness = "Legendary",
            Duration = 8
        }

    };

    public static void ShowShop(Player player)
    {
        Console.Clear();
        Console.WriteLine("=== Shop ===");
        for (int i = 0; i < AvailableItems.Count; i++)
        {
            var item = AvailableItems[i];
            Console.WriteLine($"{i + 1}. {item.Name} - {item.Description} - {item.Rareness} - ${item.Cost}");
            Console.WriteLine($"    Effects: Hunger +{item.Hunger}, Sleep +{item.Sleep}, Happiness +{item.Happiness}, Duration: {item.Duration} turns");
        }

        Console.Write("Select item to buy or 0 to go back: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && choice > 0 && choice <= AvailableItems.Count)
        {
            var item = AvailableItems[choice - 1];
            if (player.Money >= item.Cost)
            {
                player.Money -= item.Cost;
                player.Inventory.Add(item);
                Console.WriteLine($"Bought {item.Name}.");
            }
            else
            {
                Console.WriteLine("Not enough money.");
            }
        }
    }

}









