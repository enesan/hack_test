using Application.Interfaces;
using Domain.Entities;
using HackTest.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
{
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<QuestionsBase> QuestionsBases { get; set; } = null!;
    public DbSet<QuestionsGroup> QuestionsGroups { get; set; } = null!;
    public DbSet<SettingsTest> SettingsTests { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<University> Universities { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }


    
    
}