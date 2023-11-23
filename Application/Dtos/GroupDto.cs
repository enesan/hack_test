using HackTest.Entities;

namespace Application.Dtos;

public class GroupDto: BaseDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    
    public List<StudentDto>? Students { get; set; }
}