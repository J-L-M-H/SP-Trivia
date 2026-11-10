
using QuizBattle.Interfaces;

namespace QuizBattle.Models;

public class TrueFalseQuestions : Quiz, IQuestion
{
    public bool Correct { get; set; }

    public TrueFalseQuestions(
        string text,
        bool correct,
        string difficulty,
        string category)
    {
        Type = "trueFalse";
        Text = text;
        Correct = correct;
        Difficulty = difficulty;
        Category = category;
    }

    public override bool CheckAnswer(string answer)
    {
        answer = answer.ToLower();

        if (answer == "t" || answer == "true")
        {
            return Correct;
        }
        else if (answer == "f" || answer == "false")
        {
            return !Correct;
        }

        return false;
    }

    public void PrintQuestion()
    {
        Console.WriteLine("Statement: " + Text);
        Console.WriteLine("True (s) or False (f)?");
    }
}
