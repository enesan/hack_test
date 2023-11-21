namespace Domain.Entities;

public class Test
{
    public int Id { get; set; }
    
    
    public int QuestionsBaseId { get; set; }
    public QuestionsBase? QuestionsBase { get; set; }
    
}