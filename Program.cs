
using System.Data;

List<int> diceRolled = new List<int>();
int rollCount = 0;
bool runprogram = true;
while(runprogram)
{
    Console.WriteLine("Enter the number of sides for a pair of dice: ");
    int xSidedDice = 0;
    //handling non int numbers
    while (!int.TryParse(Console.ReadLine(), out xSidedDice) || xSidedDice < 0 || xSidedDice > int.MaxValue)
    {
        Console.WriteLine("Invalid response: Please use a whole number with no spaces or characters.");
    }
    Console.WriteLine($"You chose {xSidedDice} sided dice.");
    rollCount++;
    int die1 = dieRoll(xSidedDice);
    diceRolled.Add(die1);
    int die2 = dieRoll(xSidedDice);
    diceRolled.Add(die2);
    int diceTotal = addDice(die1,die2);
    Console.WriteLine($"Roll {rollCount}");
    Console.WriteLine($"You rolled {die1} and {die2}. The total is {diceTotal}");

    if (xSidedDice == 6)
    {
        Console.WriteLine(sixSidedDice(die1,die2));
    }
    else
    {
        Console.WriteLine(otherSidedDice(die1,die2));
    }
    exitProgram(ref runprogram);
}
Console.WriteLine("Thank you for using the dice roller.");
Console.WriteLine($"Today you rolled {diceRolled.Count} dice.");
Console.WriteLine($"The total of all {diceRolled.Count} dice was {diceRolled.Sum()}");
Console.Write($"Each dice rolled was ");
string allDice = "";
foreach (int dice in diceRolled)
{
    allDice += $"{dice}, ";
}
Console.Write(allDice.TrimEnd(' ', ',') + ".");


//Methods---------------------------------------------------------------------------------------------------------
static int dieRoll(int xSidedDice)
{
    Random diceRoller = new Random();

    return diceRoller.Next(1, xSidedDice + 1);
}

static string sixSidedDice(int die1, int die2)
{

    if (die1 == 1 && die2 == 1)
    {
        return $"Snake Eyes: Two 1s. \r\nCraps: A total of {die1 + die2}.";
    }
    else if((die1 == 1|| die1== 2) && (die2 == 1 || die2 == 2))
    {
        return $"Ace Deuce: A 1 and 2.\r\nCraps: A total of {die1 + die2}.";

    }
    else if(die1==6&& die2 == 6)
    {
        return $"Box Cars: Two 6s.\r\nCraps: A total of {die1 + die2}.";
    }
    else if(die1 + die2== 7 || die1 + die2 == 11)
    {
        return $"Win: A total of {die1+die2}.";
    }
    else
    {
        return "";
    }
}
static int addDice(int die1, int die2)
{
    return die1 + die2;
}
static void exitProgram(ref bool x)
{
    while (true)
    {
        Console.WriteLine("Would you like to roll again?");
        string answer = Console.ReadLine().ToLower().Trim();

        if (answer.Contains('y'))
        {
            Console.Clear();
            break;
        }
        else if (answer.Contains('n'))
        {
            x = false;
            break;
        }
        else
        {
            Console.WriteLine("Please use y/n");
        }
    }
}
static string otherSidedDice(int die1, int die2)
{

    if (die1 > die2)
    {
        return "Die one wins.";
    }
    else if (die1 < die2)
    {
        return "Die 2 wins.";
    }
    else
    {
        return $"Die 1 and Die 2 are the same.";
    }
}