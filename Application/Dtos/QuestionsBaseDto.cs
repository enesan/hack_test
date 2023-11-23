using HackTest.Entities;

namespace Application.Dtos;

public class QuestionsBaseDto: BaseDto
{
    public int Id { get; set; }
    
    public int SubjectId { get; set; }
    
    public List<TestDto>? Tests { get; set; }
    public List<QuestionsGroupDto>? QuestionsGroups { get; set; }
    
}