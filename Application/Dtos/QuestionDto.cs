using HackTest.Entities;

namespace Application.Dtos;

public class QuestionDto: BaseDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string CommentRight { get; set; }
    public string CommentWrong { get; set; }
    public double Score { get; set; }

    public IEnumerable<QuestionsGroupDto>? QuestionsGroups { get; set; }
    public IEnumerable<AnswerDto>? Answers { get; set; }

    public QuestionDto()
    {
        QuestionsGroups = new List<QuestionsGroupDto>();
        Answers = new List<AnswerDto>();
    }

}