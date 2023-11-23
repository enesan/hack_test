namespace Domain.Entities;

public class University: BaseEntity
{
    public string Name { get; set; }
    
    public List<Student>? Students { get; set; }

    public University()
    {
        Students = new List<Student>();
    }
}