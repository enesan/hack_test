namespace Domain.Entities;

public class Subject: BaseEntity
{
    public string Name { get; set; }

    public IEnumerable<QuestionsBase>? QuestionsBases { get; set; }
    public IEnumerable<Group>? Groups { get; set; }

    public Subject()
    {
        QuestionsBases = new List<QuestionsBase>();
        Groups = new List<Group>();
    }
}