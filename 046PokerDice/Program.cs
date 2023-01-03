Console.Clear();

int dice1 = 0, dice2 = 0, dice3 = 0, dice4 = 0, dice5 = 0;
bool fixed1 = false, fixed2 = false, fixed3 = false, fixed4 = false, fixed5 = false;
string input;
int number1 = 0;
int number2 = 0;
int number3 = 0;
int number4 = 0;
int number5 = 0;
int hand1 = 0;
int hand2 = 0;
int playertemp = 0;
const string PLAYER1_WINS = "Player 1 wins!";
const string PLAYER2_WINS = "Player 2 wins!";


void RollDice()
{
    if (!fixed1)
    {
        dice1 = Random.Shared.Next(1, 7);
    }
    if (!fixed2)
    {
        dice2 = Random.Shared.Next(1, 7);
    }
    if (!fixed3)
    {
        dice3 = Random.Shared.Next(1, 7);
    }
    if (!fixed4)
    {
        dice4 = Random.Shared.Next(1, 7);
    }
    if (!fixed5)
    {
        dice5 = Random.Shared.Next(1, 7);
    }
}
void PrintDice(int round)
{
    System.Console.WriteLine($"Dice roll #{round} (out of 3): {dice1}, {dice2}, {dice3}, {dice4}, {dice5}");
}
void FixDice()
{
    fixed1 = false;
    fixed2 = false;
    fixed3 = false;
    fixed4 = false;
    fixed5 = false;

    do
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Which dice do you want to fix/unfix? (1-5, or 'r' to roll the dice)");
        input = (Console.ReadLine()!);
        switch (input)
        {
            case "1":
                fixed1 = !fixed1;
                break;
            case "2":
                fixed2 = !fixed2;
                break;
            case "3":
                fixed3 = !fixed3;
                break;
            case "4":
                fixed4 = !fixed4;
                break;
            case "5":
                fixed5 = !fixed5;
                break;
            case "r":
                break;
            default:
                System.Console.WriteLine("WHAT?");
                break;
        }
        System.Console.WriteLine("Fixed: ");
        if (fixed1)
        {
            System.Console.Write("1 ");
        }
        if (fixed2)
        {
            System.Console.Write("2 ");
        }
        if (fixed3)
        {
            System.Console.Write("3 ");
        }
        if (fixed4)
        {
            System.Console.Write("4 ");
        }
        if (fixed5)
        {
            System.Console.Write("5 ");
        }
    }
    while (input != "r");
}
void SortDice()
{
    bool sorted = true;
    do
    {
        sorted = false;
        if (number1 > number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;
            sorted = true;
            // or (number1, number2) = (number2, number1)
            // Toople/ Dreieckstausch
        }
        if (number2 > number3)
        {
            int temp = number2;
            number2 = number3;
            number3 = temp;
            sorted = true;
        }
        if (number3 > number4)
        {
            int temp = number3;
            number3 = number4;
            number4 = temp;
            sorted = true;
        }
        if (number4 > number5)
        {
            int temp = number4;
            number4 = number5;
            number5 = temp;
            sorted = true;
        }
    }
    while (sorted);
    Console.WriteLine();
    System.Console.WriteLine($"Sorted: {number1}, {number2}, {number3}, {number4}, {number5}");
    System.Console.WriteLine("=====================");
}
void AnalyzeAndPrintResult()
{
    if (number1 == number2 && number2 == number3 && number3 == number4 && number4 == number5 && number1 == number5)
    {
        System.Console.WriteLine("Five of a kind");
        if (playertemp == 1)
        {
            hand1 = 8;
        }
        else
        {
            hand2 = 8;
        }
    }
    else if (number1 == number2 && number2 == number3 && number3 == number4 || number2 == number3 && number3 == number4 && number4 == number5)
    {
        System.Console.WriteLine("Four of a kind");
        if (playertemp == 1)
        {
            hand1 = 7;
        }
        else
        {
            hand2 = 7;
        }
    }
    else if (number4 == number5 && number1 == number2 && number2 == number3 || number1 == number2 && number3 == number4 && number4 == number5)
    {
        System.Console.WriteLine("Full House");
        {
            if (playertemp == 1)
            {
                hand1 = 6;
            }
            else
            {
                hand2 = 6;
            }
        }
    }
    else if (number1 == number2 && number2 == number3 || number3 == number4 && number4 == number5)
    {
        System.Console.WriteLine("Three of a kind");
        if (playertemp == 1)
        {
            hand1 = 5;
        }
        else
        {
            hand2 = 5;
        }
    }
    else if (dice1 <= dice2 && dice2 <= dice3 && dice3 <= dice4 && dice4 <= dice5)
    {
        System.Console.WriteLine("Straight");
        if (playertemp == 1)
        {
            hand1 = 4;
        }
        else
        {
            hand2 = 4;
        }
    }
    else if (number1 == number2 && number4 == number5 || number1 == number2 && number3 == number4 || number2 == number3 && number4 == number5)
    {
        System.Console.WriteLine("Two pairs");
        if (playertemp == 1)
        {
            hand1 = 3;
        }
        else
        {
            hand2 = 3;
        }
    }
    else if (number1 == number2 || number2 == number3 || number3 == number4 || number4 == number5)
    {
        System.Console.WriteLine("One pair");
        if (playertemp == 1)
        {
            hand1 = 2;
        }
        else
        {
            hand2 = 2;
        }
    }
    else if (number1 != number2 && number2 != number3 && number3 != number4 && number4 != number5)
    {
        System.Console.WriteLine("Bust");
        if (playertemp == 1)
        {
            hand1 = 1;
        }
        else
        {
            hand2 = 1;
        }
    }

}
void DetermineWinner()
{
    if (hand1 == hand2)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Oh Oh! It's a Tie!");
    }
    else if (hand1 > hand2)
    {
        System.Console.WriteLine();
        System.Console.WriteLine(PLAYER1_WINS);
    }
    else
    {
        System.Console.WriteLine();
        System.Console.WriteLine(PLAYER2_WINS);
    }
}
void PlayGame(int player)
{
    System.Console.WriteLine();
    System.Console.WriteLine($"PLAYER {player}:");
    System.Console.WriteLine("=========");
    System.Console.WriteLine();
    if (player == 1)
    {
        playertemp = 1;
    }
    if (player == 2)
    {
        playertemp = 2;
    }
    fixed1 = fixed2 = fixed3 = fixed4 = fixed5 = false;
    for (int i = 1; i <= 3 && !(fixed1 == true && fixed2 == true && fixed3 == true && fixed4 == true & fixed5 == true); i++)
    {

        RollDice();
        PrintDice(i);
        number1 = dice1;
        number2 = dice2;
        number3 = dice3;
        number4 = dice4;
        number5 = dice5;
        if (i < 3)
        {
            FixDice();
        }
    }
    SortDice();
    AnalyzeAndPrintResult();
}

PlayGame(1);
PlayGame(2);
DetermineWinner();


