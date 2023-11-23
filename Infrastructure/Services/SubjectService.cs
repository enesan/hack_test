using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class SubjectService : ISubjectService
{
    private readonly IApplicationDbContext _context;
    
    public SubjectService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<SubjectDto> CreateAsync(SubjectDto dto)
    {
        var subject = new Subject
        {
            Name = dto.Name,
        };

        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();
        
        return new SubjectDto
        {
            Id = subject.Id,
            Name = subject.Name
        };
    }
    
    public async Task<SubjectDto> GetByIdAsync(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);

        if (subject == null)
            throw new NullReferenceException("Сущность не найдена");

        return new SubjectDto
        {
            Id = subject.Id,
            Name = subject.Name
        };
    }
    
    // Read
    public async Task<ICollection<SubjectDto>> GetAllAsync()
    {
        return await _context.Subjects
            .Select(subject => new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name
            })
            .ToListAsync();
    }
    
    // Update
    public async Task<SubjectDto> UpdateAsync(SubjectDto dto)
    {
        var subject = await _context.Subjects.FindAsync(dto.Id);

        if (subject == null)
            throw new NullReferenceException("Сущность не найдена");

        subject.Name = dto.Name;

        _context.Subjects.Update(subject);
        await _context.SaveChangesAsync();
        
        return new SubjectDto()
        {
            Id = subject.Id,
            Name = subject.Name
        };
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);

        if (subject == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
    }
}