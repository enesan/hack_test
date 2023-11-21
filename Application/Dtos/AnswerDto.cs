namespace HackTest.Entities;

public class AnswerDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsRight { get; set; }
    
    public int QuestionId { get; set; }
 
}