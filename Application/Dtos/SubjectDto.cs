using Domain.Entities;

namespace Application.Dtos;

public class SubjectDto: BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public IEnumerable<QuestionsBaseDto>? QuestionsBases { get; set; }
    public IEnumerable<GroupDto> Groups { get; set; }

    public SubjectDto()
    {
        QuestionsBases = new List<QuestionsBaseDto>();
        Groups = new List<GroupDto>();
    }

}