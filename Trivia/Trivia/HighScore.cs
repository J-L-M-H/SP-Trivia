using System.Text.Json;

namespace Trivia
{
    public class HighScore
    {
        public List<Player> Highscorelist { get; set; } = new List<Player>();

        public const string FileName = "highScore.json";

        public void UpdateScore(Player player)
        {
            Highscorelist.Add(player);

            Highscorelist = Highscorelist.OrderByDescending(u => u.Points).Take(10).ToList();

            //Topplistan sparas i en JSON-fil 
            string json = JsonSerializer.Serialize(Highscorelist); //Serialize omvandlar string till json data

            File.WriteAllText(FileName, json);
        }
        public void FetchScore()
        {

            if (!File.Exists(FileName))
            {
                Highscorelist = new List<Player>();
                Console.WriteLine("The file is corrupted.");
                return;
            }
                //läses in Topplistan från JSON när programmet startar 
                string jsonFile = File.ReadAllText(FileName);

                Highscorelist = JsonSerializer.Deserialize<List<Player>>(jsonFile); //Deserialize omvandlar Json data to Plain text (string)
            
        }


        public void ShowHighscore()
        {
            Console.WriteLine("Top list");

            if (Highscorelist.Count == 0)
            {
                Console.WriteLine("No data");
                return;
            }

            for (int i = 0; i < Highscorelist.Count; i++)
            {
                Player player = Highscorelist[i];

                Console.WriteLine(
                    $"{i + 1}Player: {player.Name} Points: {player.Points} Correct Answers: {player.CorrectAnswers} Date: {player.Date}"
                );
            }
        }
    }
}
        