namespace Domain.Entities;

public class QuestionsBase: BaseEntity
{
    
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public IEnumerable<Test>? Tests { get; set; }
    public IEnumerable<QuestionsGroup>? QuestionsGroups { get; set; }
    
    public QuestionsBase()
    {
        Tests = new List<Test>();
        QuestionsGroups = new List<QuestionsGroup>();
    }
    
}