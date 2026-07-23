Random random = new Random();
bool playAgain = true;
string player;
string computer;
string ans = "";
while (playAgain)
{
    player = "";
    computer = "";
    while(player!= "rock" && player != "paper" && player != "scissors")
    {
        Console.WriteLine("Enter ROCK, PAPER or SCISSORS: ");
        player = Console.ReadLine();
        player = player.ToLower();
    }
    int randomNum = random.Next(1, 4);
    switch (randomNum)
    {
        case 1:
            computer = "rock";
            break;
        case 2:
            computer = "paper";
            break;
        case 3:
            computer = "scissors";
            break;
    }
    Console.WriteLine("Player: " + player);
    Console.WriteLine("Computer: " + computer);
    

    switch (player)
    {
        case "rock":
            if (computer == "rock")
                Console.WriteLine("It's a draw!");
            else if (computer == "paper")
                Console.WriteLine("You lose!");
            else
                Console.WriteLine("You win!");
            break;
        case "paper":
            if (computer == "rock")
                Console.WriteLine("You win!");
            else if (computer == "paper")
                Console.WriteLine("It's a draw!");
            else
                Console.WriteLine("You lose!");
            break;
        case "scissors":
            if (computer == "rock")
                Console.WriteLine("You lose!");
            else if (computer == "paper")
                Console.WriteLine("You win!");
            else
                Console.WriteLine("It's a draw!");
            break;
            
    }
    Console.WriteLine("Would you like to play again(Y/N): ");
    ans = Console.ReadLine();
    ans = ans.ToLower();
    if(ans == "y")
    {
        playAgain=true;
    }
    else
    {
        playAgain = false;
    }
}
