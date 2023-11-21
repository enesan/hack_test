namespace HackTest.Entities;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    
    public int GroupId { get; set; }
    public int UniversityId { get; set; }

}