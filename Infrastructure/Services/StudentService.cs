using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using HackTest.Entities;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly IApplicationDbContext _context;

    public StudentService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<StudentDto> CreateAsync(StudentDto model)
    {
        var student = new Student()
        {
            FirstName = model.FirstName,
            MiddleName = model.MiddleName,
            LastName = model.LastName,
            GroupId = model.GroupId,
            UniversityId = model.UniversityId,
        };

        await _context.Students.AddAsync(student);
       // await _context.SaveChangesAsync();

       return new StudentDto()
       {
           Id = student.Id,
           FirstName = student.FirstName,
           MiddleName = student.MiddleName,
           LastName = student.LastName,
           GroupId = student.GroupId,
           UniversityId = student.UniversityId,
       };

    }
}