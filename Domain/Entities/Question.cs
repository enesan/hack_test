using Domain.Entities;

namespace Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string CommentRight { get; set; }
    public string CommentWrong { get; set; }

    public List<QuestionsGroup>? QuestionsGroups { get; set; }
    public List<Answer>? Answers { get; set; }

    public Question()
    {
        QuestionsGroups = new List<QuestionsGroup>();
        Answers = new List<Answer>();
    }
}