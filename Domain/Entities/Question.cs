using Domain.Entities;

namespace Domain.Entities;

public class Question: BaseEntity
{
    public string Text { get; set; }
    public string CommentRight { get; set; }
    public string CommentWrong { get; set; }
    public double Score { get; set; }

    public IEnumerable<QuestionsGroup>? QuestionsGroups { get; set; }
    public IEnumerable<Answer>? Answers { get; set; }

    public Question()
    {
        QuestionsGroups = new List<QuestionsGroup>();
        Answers = new List<Answer>();
    }
}