using System;

public static class Shop
{
    public static List<Item> AvailableItems = new List<Item> 
    
    {
        new Item
        {
            Name = "Food",
            Description = "Restores hunger",
            Cost = 1,
            Hunger = 20,
            Sleep = 0,
            Happiness = 0,
            Duration = 2
        },
        new Item
        {
            Name = "Toy",
            Description = "Increases happiness",
            Cost = 15,
            Hunger = 0,
            Sleep = 0,
            Happiness = 30,
            Duration = 3
        },
        new Item
        {
            Name = "Bed",
            Description = "Improves sleep",
            Cost = 20,
            Hunger = 0,
            Sleep = 25,
            Happiness = 0,
            Duration = 4
        }
    };
    

    
    
    public static void ShowShop(Player player)
    {
        Console.Clear();
        Console.WriteLine("=== Shop ===");
        for (int i = 0; i < AvailableItems.Count; i++)
        {
            var item = AvailableItems[i];
            Console.WriteLine($"{i + 1}. {item.Name} - {item.Description} - ${item.Cost}");
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

