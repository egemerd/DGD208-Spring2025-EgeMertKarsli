using System;

public static class Shop
{
    public static List<Item> AvailableItems = new List<Item>
    {
        new Item("Food", "Restores hunger", 10, +20, 0, 0,2),
        new Item("Toy", "Increases happiness", 15, 0, 0, +30,3),
        new Item("Bed", "Improves sleep", 20, 0, +25, 0,4)
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

