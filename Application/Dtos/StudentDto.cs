using Domain.Entities;

namespace Application.Dtos;

public class StudentDto: BaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int GroupId { get; set; }
    public GroupDto Group { get; set; }
    public int UniversityId { get; set; }
    public UniversityDto University { get; set; }

}