using System;
using System.Collections.Generic;

public static class ItemDatabase
{
    public static List<Item> ItemList = new List<Item>
    {
        new Item
        {
            Name = "Food",
            Description = "Restores hunger",
            Cost = 10,
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
}
