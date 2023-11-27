namespace Application.Dtos;

public class UniversityDto: BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public IEnumerable<StudentDto>? Students { get; set; }

    public UniversityDto()
    {
        Students = new List<StudentDto>();
    }
    
}