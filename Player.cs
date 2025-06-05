using System;

public class Player
{
    public StarterType StarterBonus { get; private set; }
    public int Money { get; set; } = 0;
    public Player() { }

    public Player(StarterType starterBonus)
    {
        StarterBonus = starterBonus;
    }

    public int ApplyMoneyBonus(int baseMoney)
    {
        return StarterBonus == StarterType.Cat ? baseMoney * 2 : baseMoney;
    }

    public int ApplyItemDuration(int baseDuration)
    {
        return StarterBonus == StarterType.Monkey ? baseDuration / 2 : baseDuration;
    }

    public int ApplyStatDecay(int baseDecay)
    {
        return StarterBonus == StarterType.Rabbit ? baseDecay / 2 : baseDecay;
    }

    public void ShowMoney() 
    {
        Console.WriteLine($"Money: {Money}");  
    }

    public void AddMoney(int amount) 
    {
        int finalAmount = ApplyMoneyBonus(amount);
        Money += finalAmount;
        
    }
}
