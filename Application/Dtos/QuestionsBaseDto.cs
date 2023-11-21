namespace HackTest.Entities;

public class QuestionsBaseDto
{
    public int Id { get; set; }
    
    public int SubjectId { get; set; }
    
    public List<TestDto>? Tests { get; set; }
    public List<QuestionsGroupDto>? QuestionsGroups { get; set; }
    
}