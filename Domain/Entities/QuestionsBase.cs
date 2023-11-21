namespace Domain.Entities;

public class QuestionsBase
{
    public int Id { get; set; }
    
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public List<Test>? Tests { get; set; }
    public List<QuestionsGroup>? QuestionsGroups { get; set; }
    
    public QuestionsBase()
    {
        Tests = new List<Test>();
        QuestionsGroups = new List<QuestionsGroup>();
    }
    
}