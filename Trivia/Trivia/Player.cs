
namespace consoleAPP1;


public class Player
{
    public string Name { get; set; }
    public int Points { get; set; }
    public int CorrectAnswers { get; set; }
    public DateTime Date { get; set; }
    public int CorrectInRow { get; set; }
    public Player(string name)
    {
        Name = name;
        Points = 0;
        CorrectAnswers = 0;
        Date = DateTime.Now;
        CorrectInRow = 0;
    }
    public void UpdatePoints(int difficultyPoints)
    {
        Points += difficultyPoints;
    }
    public void UpdateCorrectAnswers()
    {
        CorrectAnswers++;
    }
    public void UpdateCorrectInRow(bool isCorrect)
    {
        if (isCorrect)
        {
            CorrectInRow++;
        }
        else
        {
            CorrectInRow = 0;
        }
    }
}



