namespace Application.Dtos;

public class SubjectDto: BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<QuestionsBaseDto>? QuestionsBases { get; set; }

}