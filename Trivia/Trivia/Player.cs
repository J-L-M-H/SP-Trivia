namespace Trivia;


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
        
        int seriesBonus = 0;
        if(CorrectInRow == 2)
        {
            seriesBonus = 5;
        }
        else if (CorrectInRow == 3)
        {
            seriesBonus = 10;
        }
        else if (CorrectInRow == 4)
        {
            seriesBonus = 15;
        }
        else if (CorrectInRow >= 5)
        {
            seriesBonus = 20;
        }
        
        Points += difficultyPoints + seriesBonus;

        //seriebonusen
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



