using System.Text.Json.Serialization;

//kommer C# att skapa rätt frågeklass automatiskt utifrån "type" i JSON-filen. Det betyder att du i nuläget inte behöver anropa din parameterkonstruktor manuellt i klasserna ChoiceQuestion och TrueFalseQuestions.
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ChoiceQuestion), "multipleChoice")]
[JsonDerivedType(typeof(TrueFalseQuestions), "trueFalse")]
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