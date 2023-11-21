namespace HackTest.Entities;

public class GroupDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    
    public List<StudentDto>? Students { get; set; }
}