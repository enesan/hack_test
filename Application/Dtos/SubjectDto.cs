namespace HackTest.Entities;

public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<QuestionsBaseDto>? QuestionsBases { get; set; }

}