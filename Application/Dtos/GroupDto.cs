using HackTest.Entities;

namespace Application.Dtos;

public class GroupDto: BaseDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    
    public IEnumerable<StudentDto>? Students { get; set; }
    public IEnumerable<SubjectDto> Subjects { get; set; }

    public GroupDto()
    {
        Students = new List<StudentDto>();
        Subjects = new List<SubjectDto>();
    }
}