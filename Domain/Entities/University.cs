namespace Domain.Entities;

public class University
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Student>? Students { get; set; }

    public University()
    {
        Students = new List<Student>();
    }
}