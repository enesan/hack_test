namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public int Number { get; set; }
    
    public List<Student>? Students { get; set; }

    public Group()
    {
        Students = new List<Student>();
    }
}