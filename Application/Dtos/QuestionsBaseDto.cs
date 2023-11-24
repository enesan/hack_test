using HackTest.Entities;

namespace Application.Dtos;

public class QuestionsBaseDto: BaseDto
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    
    public IEnumerable<TestDto>? Tests { get; set; }
    public IEnumerable<QuestionsGroupDto>? QuestionsGroups { get; set; }


    public QuestionsBaseDto()
    {
        Tests = new List<TestDto>();
        QuestionsGroups = new List<QuestionsGroupDto>();
    }
}