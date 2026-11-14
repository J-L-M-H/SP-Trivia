public class ChoiceQuestion: Quiz, IQuestion
{
    public List<string> Options { get; set; }
    public int CorrectIndex { get; set; }

    public ChoiceQuestion(string text, List<string> options, int correctIndex, string difficulty, string category)
    {
        Type = "multipleChoice";
        Text = text;
        Options = options;
        CorrectIndex = correctIndex;
        Difficulty = difficulty;
        Category = category;
    }

     public override bool CheckAnswer(string answer)
    {
        int ans = int.Parse(answer);
        if(answer != "" && answer != null)
        {
            int input = int.Parse(answer);
            //villkor som retunerar true om det stämmer
            return input == CorrectIndex +1; //CorrectIndex +1 för att räkningen eller indexet börjar från 0

        }
        if(ans <= 1 && ans >= Options.Count + 1)
        {
            Console.WriteLine("Invalid answer, Try again");
        }
        return false;
    }

    public void PrintQuestion()
    {
        Console.WriteLine($"{Category}, {GetPoints()} points");
        Console.WriteLine(Text);

        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
    }
}