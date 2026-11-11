namespace Trivia;

public class GameLogic
{
        public List<Quiz> availableList { get; set; } = new List<Quiz>();

        public int RoundNumber { get; set; }

        public int TargetRound { get; set; }

        public bool CloseGame { get; set; }

        public Player player;

        public GameLogic()
        {
            RoundNumber = 1;
            TargetRound = 1;
            CloseGame = false;
        }

        public void PlayRound(List<Player> players)
    {
        int numberOfPlayers = 0;
        string answer;
        string name = "";

        //matar in antal spelare och kollar om det är mellan 2 och 4 spelare
        while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                Console.Write("Number of players (2-4): ");

                 answer = Console.ReadLine() ;

              
                    numberOfPlayers = int.Parse(answer);

                    if (numberOfPlayers < 2 || numberOfPlayers > 4)
                    {
                        Console.WriteLine("Choose between 2 and 4 players.");
                    }
                
                
            }

        //gå igenom numberOfPlayers så att alla eller varje spelare matar in sitt namn
        for (int i = 0; i < numberOfPlayers; i++)
        {

        while (name == ""){
                Console.Write("Name of player " + (i + 1) + ": "); // ex. Namn på spelare 1: Maja Namn på spelare 2: john

                name= Console.ReadLine();

                if (name == "")
            {
                Console.WriteLine("Name cannot be empty.");
                continue;
            }

            foreach (Player player in players)
            {
                if (player.Name == name)
                {
                    Console.WriteLine("this name is alredy exists");
                }
            }

            players.Add(new Player(name));
            }
        }


    }

}