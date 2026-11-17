namespace Trivia;

public class Program
{
    
    static void Main()
    {

        HighScore h = new HighScore();

        //Laddar alla sparade highscors
        h.FetchScore();

        // Skickar HighScore-objekt med all sparade data till GameLogic
        GameLogic g = new GameLogic(h);

        string input = "";

        while (input == "")
        {
            
            Console.WriteLine("\n === Quiz Battle ===");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Top list");
            Console.WriteLine("3. Exit");

            Console.Write("Enter: ");

            input = Console.ReadLine(); 
            

            switch (input)
            {
                case "1":
                    g.StartGame();
                    break;

                case "2":
                    h.ShowHighscore();
                    break;

                case "3":
                    Console.WriteLine("Goodbye");
                    break;

                default:
                    Console.WriteLine("invalid input choose between 1 and 3.");
                    input = "";
                    break;
            }
        }
    }

}
