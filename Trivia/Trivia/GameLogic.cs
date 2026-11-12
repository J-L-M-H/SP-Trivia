using System.Text.Json;

namespace Trivia;

public class GameLogic
{
    public List<Quiz> availableList { get; set; } = new List<Quiz>();
    public List<Player> players { get; set; } = new List<Player>();
    public int RoundNumber { get; set; }
    public int TargetRound { get; set; }
    public bool CloseGame { get; set; }

    public const string FileName = "questions.json";

    public HighScore highScore;

    public GameLogic(HighScore score)
    {
        TargetRound = 0;
        RoundNumber = 0;
        CloseGame = false;
        highScore = score;
    }

    //startar ett nytt spel
     public void StartGame()
    {
            //tömmer listorna varje gång vi kör ett nytt spel
            availableList.Clear();
            players.Clear();

            int numberOfPlayers = 0;

            //matar in antal spelare och kollar om det är mellan 2 och 4 spelare
            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                Console.Write("Number of players (2-4): ");

                string answer = Console.ReadLine();

                try
                {
                    numberOfPlayers = int.Parse(answer);

                    if (numberOfPlayers < 2 || numberOfPlayers > 4)
                    {
                        Console.WriteLine("Choose between 2 and 4 players.");
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a valid number.");
                }
            }

            //gå igenom numberOfPlayers så att alla eller varje spelare matar in sitt namn
            for (int i = 0; i < numberOfPlayers; i++)
            {
                string name = "";

                while (name == "")
                {
                    Console.Write("Name of player " + (i + 1) + ": "); // ex. Namn på spelare 1: Maja Namn på spelare 2: john

                    name = Console.ReadLine();

                    if (name == "")
                    {
                        Console.WriteLine("Name cannot be empty.");
                    }
                    else
                    {
                        //kontrollerar om namnet redan finns
                        foreach (Player player in players)
                        {
                            if (player.Name.Equals(name))
                            {
                                Console.WriteLine("Name already exists.");
                            }
                        }

                    }
                }

                Player newPlayer = new Player(name);
                players.Add(newPlayer);
            }

            
            //matar in antal rundor och kollar om det är mellan 1 och 10 rundor
            while (TargetRound < 1 || TargetRound > 10)
            {
                Console.Write("Number of rounds (1-10): ");

                string answer = Console.ReadLine();

                try
                {
                    TargetRound = int.Parse(answer);

                    if (TargetRound < 1 || TargetRound > 10)
                    {
                        Console.WriteLine("Choose between 1 and 10 rounds.");
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a valid number.");
                }
            }

            // här skapas frågårna och hämtas från json efter att alla spelare matat in all data 
            availableList = CreateList();


            // Kör rundan
            while (RoundNumber <= TargetRound && !CloseGame)
            {
                PlayRound(players);
            }

    }

    public List<Quiz> CreateList()

    {
        string json = File.ReadAllText("questions.json");

        var questionData = JsonSerializer.Deserialize<QuestionData>(json);

        var questions = questionData.Categories

        .SelectMany(category => category.Questions.Select(question =>

        {question.Category = category.Name;}))

        .ToList();

            return questions;

    }
        
        public Quiz PickQuestion()
    {
        // kontrollerar alla spelare har fått en fråga
            if (availableList.Count < players.Count)
            {
                Console.WriteLine("\nNot enough questions available only " + availableList.Count + " questions available.");
                CloseGame = true;
                return null;
            }

            List<string> categories = availableList.Select(question => question.Category).ToList(); //skapar lista av alla category som vi har

            Quiz selectedQuestion = null;
            availableList.Remove(selectedQuestion);
            
            return selectedQuestion;
    }

        public void PlayRound(List<Player> players)
    {
            Console.WriteLine("=== Round " + RoundNumber + "of" + TargetRound + " ===");

            foreach (Player player in players)
        {
            if (availableList.Count == 0)
            {
                Console.WriteLine("\nNot enough questions available");
                CloseGame = true;
                return;
            }

            Console.WriteLine($"\n{player.Name}, Choose a category:");

            Quiz question = PickQuestion(); //här hämtas en fråga och sparas i variabln 'question'
            if (question == null)
            {
                CloseGame = true;
                return;
            }






            //avsluta spelet när alla rundor är klara
            if (RoundNumber > TargetRound || CloseGame)
            {
                EndGame();
            }

        }

    }

    public void EndGame()
    {
        Console.WriteLine("\n=== Final Results ===");

        List<Player> sortedPlayers = players.OrderByDescending(player => player.Points).ToList(); //skapa en lista med alla spelare och sorterar dem efter poäng

        for (int i = 0; i < sortedPlayers.Count; i++)
        {
            Player player = sortedPlayers[i];

            Console.WriteLine($"{i + 1}. {player.Name}  {player.Points} points  " + $"({player.CorrectAnswers} of {RoundNumber})");

            player.Date = DateTime.Now;

            highScore.UpdateScore(player);


        }

        int highestScore = sortedPlayers[0].Points; //listan redan är sorterad med högsta poäng så vi antar att första spelaren har högsta poäng

        int highestCorrectAnswers = 0; // den har koll på högsta korrekta svar

        // loopar vi och jämför första spelaren med alla andra spelare och hitta flest rätt bland spelarna med högst poäng
        foreach (Player player in sortedPlayers)
        {
            if (player.Points == highestScore)
            {
                if (player.CorrectAnswers > highestCorrectAnswers)
                {
                    highestCorrectAnswers = player.CorrectAnswers;
                }
            }
        }


        List<Player> winners = new List<Player>();

        //Om två spelare fortfarande har både samma högsta poäng och samma antal rätta svar hamnar båda i winners listan och delar på segern.
        foreach (Player player in sortedPlayers)
    {
        if (player.Points == highestScore && player.CorrectAnswers == highestCorrectAnswers)
        {
            winners.Add(player);
        }
    }


        if (winners.Count == 1) //om inga spelare som har samma poäng
        {
            Console.WriteLine($"\n{winners[0].Name} wins!");
        }
        else
        {
            Console.WriteLine("\nIt's a tie!");

            //skriva ut spelarna som delar segern.
            foreach (Player winner in winners)
            {
                Console.WriteLine(winner.Name);
            }
        }

        highScore.ShowHighscore();
    }
}



