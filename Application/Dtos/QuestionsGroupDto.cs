namespace HackTest.Entities;

public class QuestionsGroupDto
{
    public int Id { get; set; }
    public string Topic { get; set; }
    
    public int QuestionsId { get; set; }
    public int QuestionsBaseId { get; set; }
}