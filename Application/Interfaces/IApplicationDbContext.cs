using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Group> Groups { get; set; } 
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionsBase> QuestionsBases { get; set; }
    public DbSet<QuestionsGroup> QuestionsGroups { get; set; }
    public DbSet<SettingsTest> SettingsTests { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<University> Universities { get; set; }

     Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}