using System.Reflection.Metadata;
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

            RoundNumber = 0;
            TargetRound = 0;
            CloseGame = false;

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
            while (RoundNumber < TargetRound && !CloseGame)
            {
                RoundNumber++;
                PlayRound(players);
            }

    }

    public List<Quiz> CreateList()
{
    string json = File.ReadAllText(FileName);

    var questionData = JsonSerializer.Deserialize<QuestionData>(json);

    var questions = questionData.Categories
        .SelectMany(category => category.Questions.Select(question =>
        {
            question.Category = category.Name;
            return question;
        }))
        .ToList();

    Random random = new Random();

    var randomizedList = questions
        .OrderBy(x => random.Next())
        .ToList();

    return randomizedList;
}
        
        public Quiz PickQuestion()
    {
        // kontrollerar alla spelare har fått en fråga
            if (availableList.Count == 0)
            {
                Console.WriteLine("\nNot enough questions available");
                CloseGame = true;
                return null;
            }

            
            /*
            Maja, välj kategori:
            1. Programmering (6 frågor kvar)
            2. Geografi (6 frågor kvar)
            3. Allmänbildning (6 frågor kvar)
            4. Slumpa
            */
            List<string> categories = availableList.Select(question => question.Category).Distinct().ToList(); //skapar lista av alla category som vi har och tar bort dubbletter

            for(int i=0; i< categories.Count; i++)
        {
            int count = availableList.Count(question => question.Category == categories[i]); //hämtar antal frågor för en viss categori 
            Console.WriteLine($"{i + 1}. {categories[i]} {categories[i]} {count} questions available");
        }
            Console.WriteLine($"{categories.Count + 1}. Random");

            int choice; //välja kategori du vill

            while (true)
            {
                Console.Write("choice: ");

                choice = int.Parse(Console.ReadLine());

                if (choice < 1 && choice > categories.Count)
                {
                    break;
                }

                Console.WriteLine("Invalid choice. Try again.");
            }

            string pickedcategory; //spara kategorin du har valt

            //här behandlas din val
            if (choice != categories.Count + 1) //om valet är inte 4 dvs inte slumpa
            {
                pickedcategory = categories[choice-1]; //index i listan börjar från 0
            }
            //Om valet är 4
            else
            {
                pickedcategory= categories[0];
            }

            //skapa en lista med de frågorna som kategorin innehåller dvs från kategorin du har val
            List<Quiz> categoryQuestions = availableList.Where(question => question.Category == pickedcategory).ToList();
        
            Quiz selectedQuestion = categoryQuestions[0];
            availableList.Remove(selectedQuestion);
            
            return selectedQuestion;
    }

        public void PlayRound(List<Player> players)
    {
            Console.WriteLine("=== Round " + RoundNumber + "of" + TargetRound + " ===");

            foreach (Player player in players)
        {
            if (availableList.Count < players.Count)
            {
                Console.WriteLine($"Not enough questions available only ");
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

            // Visa frågan
        ((IQuestion)question).PrintQuestion();

        bool CloseAnswering = true;
        bool correctAnswer = true;

        // Kontrollera inmatningen
        while (CloseAnswering)
        {
            Console.Write("Your answer (1-4): ");
            string answer = Console.ReadLine();
            if (question is ChoiceQuestion choiceQuestion)
            {
                correctAnswer = choiceQuestion.CheckAnswer(answer);
            }
            else if (question is TrueFalseQuestions truefalseQuestions)
            {
                 correctAnswer = truefalseQuestions.CheckAnswer(answer);
            }

            CloseAnswering = false;
        }
        
            Console.WriteLine("Invalid answer. Try again.");

            if (correctAnswer)
            {
                player.UpdateCorrectInRow(true);
                player.UpdatePoints(question.GetPoints());
                player.UpdateCorrectAnswers();
            }
            else
            {
                player.UpdateCorrectInRow(false);
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




