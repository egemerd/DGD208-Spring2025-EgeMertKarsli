using System;

public class MainMenu
{
    private static bool isRunning = true;
    private static Player? player;
    private static CancellationTokenSource? statTokenSource;

    public static void MainMenuRun()
    {
        ShowHowToPlay();
        
        

   
        while (isRunning)
        {
            ShowMainMenu();
        }

    }

    private static void ShowHowToPlay()
    {
        Console.Clear();
        Console.WriteLine("=== How to Play ===");
        Console.WriteLine("- Adopt and care for pets.");
        Console.WriteLine("- Pet stats drop every 3 seconds.");
        Console.WriteLine("- Use items or feed them to keep them alive.");
        Console.WriteLine("=== How to Play ===");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void ShowMainMenu()
    {


        Console.Clear();
        Console.WriteLine("=== Main Menu ===");
        Console.WriteLine("1. Start New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Credits");
        Console.WriteLine("4. Quit");
        Console.Write("Select an option: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                PetManager.ClearPets();
                ChooseStarterPet();
                StartGame();
                break;
            case "2":
                player = PetManager.LoadGame();
                if (player != null)
                    StartGame();
                else
                    Console.ReadKey();
                break;
            
            case "3":
                ShowCredits();
                break;
            case "4":
                isRunning = false;

                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option.");
                Console.ReadKey();
                break;
        }

    }

    private static void ChooseStarterPet() 
    {
        Console.WriteLine("Choose your starter:");
        Console.WriteLine("1. Cat (2x Money)");
        Console.WriteLine("2. Monkey (Faster Item Use)");
        Console.WriteLine("3. Rabbit (Slower Stat Decay)");

        string input = Console.ReadLine();

        StarterType starterType = input switch
        {
            "1" => StarterType.Cat,
            "2" => StarterType.Monkey,
            "3" => StarterType.Rabbit,
            _ => StarterType.Cat
        };

        player = new Player(starterType);

        
        PetSpecies starterSpecies = (PetSpecies)Enum.Parse(typeof(PetSpecies), starterType.ToString());
        Pet starterPet = new Pet("Starter", starterSpecies);
        PetManager.AdoptPet(starterPet);
        
    }

    private static void StartGame()
    {
        

        statTokenSource = new CancellationTokenSource();
        var token = statTokenSource.Token;
        
        
        StartStatTickLoop(); 
        StartMoneyTickLoop();
        
        ShowInGameMenu();

       
    }

    private static void ShowInGameMenu() 
    {
        bool inGame = true;

        while (inGame)
        {
            Console.Clear();

            Console.WriteLine("=== Game Menu ===");
            Console.WriteLine("1. Use Item");
            Console.WriteLine("2. Feed Animals");
            Console.WriteLine("3. Adopt Animal");
            Console.WriteLine("4. Show Stats");
            Console.WriteLine("5. Show Shop");
            Console.WriteLine("6. Save Game");
            Console.WriteLine("7. Return to Main Menu");
            Console.Write("Choose an action: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UseItem();
                    Console.ReadKey();
                    break;

                case "2":
                    Food.FeedPetMenu();
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Enter name for new pet: ");
                    string newPet = Console.ReadLine();

                    Console.Write("Enter species (Dog, Horse, Coala, Panda, Fox): ");
                    string speciesInput = Console.ReadLine();

                    if (Enum.TryParse<PetSpecies>(speciesInput, true, out PetSpecies species))
                    {
                        PetManager.AdoptPet(new Pet(newPet, species));
                    }
                    else
                    {
                        Console.WriteLine("Invalid species. Please try again.");
                    }

                    
                    break;

                case "4":
                    PetManager.ShowAllPets();
                    player.ShowMoney();
                    Console.ReadKey();
                    break;
                case "5":
                    Shop.ShowShop(player);
                    Console.ReadKey();
                    break;
                case "6":
                    PetManager.SaveGame(player);
                    Console.WriteLine("Game Saved.");
                    Console.ReadKey();
                    break;

                case "7":
                    inGame = false;
                    statTokenSource.Cancel();
                    
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    Console.ReadKey();
                    break;
            }
        }


    }

    private static void ShowCredits()
    {
        Console.Clear();
        Console.WriteLine("=== Credits ===");
        Console.WriteLine("Created by Ege Mert Karslı - 225040053");
        Console.WriteLine("Honorable Mention: \nChatGPT \nFellas in Reddit \nIndian Youtubers");
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }


    private static void StartStatTickLoop()
    {
        statTokenSource = new CancellationTokenSource();
        var token = statTokenSource.Token;

        Task.Run(async () =>
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(2000);
                if (player != null)
                {
                    PetManager.TickStats(player);
                }
            }
        }, token);
    }

    private static void StartMoneyTickLoop()
    {
        Task.Run(async () =>
        {
            while (!statTokenSource.Token.IsCancellationRequested)
            {
                await Task.Delay(2000); 
                if (player != null)
                {
                    player.AddMoney(1); 
                }
            }
        }, statTokenSource.Token);
    }

    private static void UseItem()
    {
        player.ShowInventory();
        if (player.Inventory.Count == 0) return;

        Console.Write("Choose item number to use: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= player.Inventory.Count)
        {
            var item = player.Inventory[index - 1];

            var pets = PetManager.GetPets();
            if (pets.Count == 0)
            {
                Console.WriteLine("You have no pets.");
                return;
            }

            Console.WriteLine("Choose a pet to use item on:");
            for (int i = 0; i < pets.Count; i++)
                Console.WriteLine($"{i + 1}. {pets[i].Name}");

            if (int.TryParse(Console.ReadLine(), out int petIndex) && petIndex > 0 && petIndex <= pets.Count)
            {
                var pet = pets[petIndex - 1];
                item.UseAsync(pet);
                player.Inventory.Remove(item);
            }
        }


    }

    

}


