using System;

public class Food
{
	public string name { get; set; }
	public int hungerEffect { get; set; }
	public int sleepEffect { get; set; }
	public int happinessEffect { get; set; }

	public Food(string Name,int HungerEffect, int SleepEffect, int HappinessEffect) 
	{
		name = Name;
		hungerEffect = HungerEffect;
		sleepEffect = SleepEffect;	
		happinessEffect = HappinessEffect;
	}

    private static List<Food> foodItems = new List<Food>
	{
		new Food("Apple", 10, 0, 5),
		new Food("Pizza", 20, -5, 15),
		new Food("Milk", 5, 5, 5)
	};

    public void Feed(Pet pet) 
	{
		pet.Hunger += hungerEffect;
		pet.Sleep += sleepEffect;
		pet.Happiness += happinessEffect;

        Console.WriteLine($"{name} effect is used on  {pet.Name}.");
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
                Console.WriteLine($"{i + 1}. {food.name} (Hunger +{food.hungerEffect}, Sleep +{food.sleepEffect}, Happiness +{food.happinessEffect})");
            }

            if (int.TryParse(Console.ReadLine(), out int foodIndex) && foodIndex > 0 && foodIndex <= foodItems.Count)
            {
                var selectedFood = foodItems[foodIndex - 1];
                selectedFood.Feed(selectedPet);
            }
        }

        Console.ReadKey();
    }
}
