using Application.Dtos;

namespace HackTest.Entities;

public class AnswerDto : BaseDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsRight { get; set; }
    public int QuestionId { get; set; }
    public QuestionDto Question { get; set; }
 
}