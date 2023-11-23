namespace Application.Dtos;

public class QuestionsGroupDto: BaseDto
{
    public int Id { get; set; }
    public string Topic { get; set; }
    
    public int QuestionsId { get; set; }
    public int QuestionsBaseId { get; set; }
}