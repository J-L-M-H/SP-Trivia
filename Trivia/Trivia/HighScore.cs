using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Trivia
{
    internal class HighScore
    {
        public List<Player> Highscorelist { get; set; } = new List<Player>();

        public const string FileName = "highScore.json";

        public void UpdateScore(Player player)
        {
            Highscorelist.Add(player);

            Highscorelist = Highscorelist.OrderBy(u => u.Points).Take(5).ToList();

            //Topplistan sparas i en JSON-fil 
            string json = JsonSerializer.Serialize(Highscorelist, new JsonSerializerOptions
            {
                WriteIndented = true
            }); //Serialize omvandlar string till json data

            File.WriteAllText(FileName, json);
        }
        public void FetchScore()
        {

            if (!File.Exists(FileName))
            {
                Highscorelist = new List<Player>();
                Console.WriteLine("The file is corrupted.");
            }
            //läses in Topplistan från JSON när programmet startar 
            else
            {
                string jsonFile = File.ReadAllText(FileName);

                Highscorelist = JsonSerializer.Deserialize<List<Player>>(jsonFile); //Deserialize omvandlar Json data to Plain text (string)
            }
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
                    $"{i + 1}Player: {player.Name} Points: {player.Points} Correct Answers: {player.Correctanswers} Date: {player.Date}"
                );
            }
        }
    }
}
        