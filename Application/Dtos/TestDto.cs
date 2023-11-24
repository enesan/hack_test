namespace Application.Dtos;

public class TestDto: BaseDto
{
    public int Id { get; set; }
    
    public int QuestionsBaseId { get; set; }
    public QuestionsBaseDto QuestionsBase { get; set; }
    
}