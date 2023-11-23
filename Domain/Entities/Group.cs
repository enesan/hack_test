namespace Domain.Entities;

public class Group: BaseEntity
{
    public int Number { get; set; }
    
    public List<Student>? Students { get; set; }
    public List<Subject>? Subjects { get; set; }

    public Group()
    {
        Students = new List<Student>();
        Subjects = new List<Subject>();
    }
}