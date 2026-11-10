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
        if(answer != "")
        {
            int input = int.Parse(answer);
            return input == CorrectIndex;

        }
        return false;
    }

    public void PrintQuestion()
    {
        Console.WriteLine(Text);

        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
    }
}