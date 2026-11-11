public abstract class Quiz{
    public string Type { get; set; }
    public string Text { get; set; }
    public string Difficulty { get; set; }
    public string Category { get; set; }

    public abstract bool CheckAnswer(string answer);

    public int GetPoints()
    {
        if(Difficulty == "easy")
        {
            return 10;
        }
        else if(Difficulty == "medium")
        {
            return 20;
        }
        else if(Difficulty == "hard")
        {
            return 30;
        }
        else
        {
            return 0;
        }
    }

    
}