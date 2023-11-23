namespace Domain.Entities;

public class Subject: BaseEntity
{
    public string Name { get; set; }

    public List<QuestionsBase>? QuestionsBases { get; set; }

    public Subject()
    {
        QuestionsBases = new List<QuestionsBase>();
    }
}