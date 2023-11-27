using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using HackTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly IApplicationDbContext _context;

    public StudentService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<StudentDto> CreateAsync(StudentDto model)
    {
        var student = new Student
        {
            FirstName = model.FirstName,
            MiddleName = model.MiddleName,
            LastName = model.LastName,
            GroupId = model.GroupId,
            UniversityId = model.UniversityId
        };

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        return TransformToDto(student);

    }
    public async Task<StudentDto> GetByIdAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            throw new NullReferenceException("Сущность не найдена");

        return TransformToDto(student);
    }
    
    // Read
    public async Task<ICollection<StudentDto>> GetAllAsync()
    {
        return await _context.Students
            .Select(student => TransformToDto(student))
            .ToListAsync();
    }
    
    // Update
    public async Task<StudentDto> UpdateAsync(StudentDto dto)
    {
        var student = await _context.Students.FindAsync(dto.Id);

        if (student == null)
            throw new NullReferenceException("Сущность не найдена");

        student.FirstName = dto.FirstName;
        student.MiddleName = dto.MiddleName;
        student.LastName = dto.LastName;
        student.GroupId = dto.GroupId;
        student.UniversityId = dto.UniversityId;
        
        _context.Students.Update(student);
        await _context.SaveChangesAsync();

        return TransformToDto(student);
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    private static StudentDto TransformToDto(Student student)
    {
        return new StudentDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            MiddleName = student.MiddleName,
            LastName = student.LastName,
            GroupId = student.GroupId,
            UniversityId = student.UniversityId
        };
    }
}