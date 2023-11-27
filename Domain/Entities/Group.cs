namespace Domain.Entities;

public class Group: BaseEntity
{
    public int Number { get; set; }
    
    public IEnumerable<Student>? Students { get; set; }
    public IEnumerable<Subject>? Subjects { get; set; }

    public Group()
    {
        Students = new List<Student>();
        Subjects = new List<Subject>();
    }
}