namespace Domain.Entities;

public class QuestionsGroup
{
    public int Id { get; set; }
    public string Topic { get; set; }
    
    public int QuestionsId { get; set; }
    public Question? Question { get; set; }
    
    public int QuestionsBaseId { get; set; }
    public QuestionsBase? QuestionsBase { get; set; }
}