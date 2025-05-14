using System;

public class MainMenu
{
    private static bool isRunning = true;

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
                StartNewGame();
                break;
            case "2":
                Console.WriteLine("Load Game not implemented yet.");
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


    private static void StartNewGame()
    {
        Console.WriteLine("StartNewGame");
    }

    private static void ShowCredits()
    {
        Console.WriteLine("ShowCredits");
    }




}


