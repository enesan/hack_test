namespace Domain.Entities;

public class Test: BaseEntity
{
    
    
    public int QuestionsBaseId { get; set; }
    public QuestionsBase? QuestionsBase { get; set; }
    
}