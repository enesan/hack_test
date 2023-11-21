namespace Domain.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<QuestionsBase>? QuestionsBases { get; set; }

    public Subject()
    {
        QuestionsBases = new List<QuestionsBase>();
    }
}