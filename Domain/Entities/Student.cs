namespace Domain.Entities;

public class Student: BaseEntity
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    
    public int GroupId { get; set; }
    public Group? Group { get; set; }
    
    public int UniversityId { get; set; }
    public University? University { get; set; }
}