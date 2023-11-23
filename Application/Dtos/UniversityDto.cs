namespace Application.Dtos;

public class UniversityDto: BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<StudentDto>? Students { get; set; }
    
}