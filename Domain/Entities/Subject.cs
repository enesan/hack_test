namespace Domain.Entities;

public class Subject: BaseEntity
{
    public string Name { get; set; }

    public List<QuestionsBase>? QuestionsBases { get; set; }
    public List<Group>? Groups { get; set; }

    public Subject()
    {
        QuestionsBases = new List<QuestionsBase>();
        Groups = new List<Group>();
    }
}