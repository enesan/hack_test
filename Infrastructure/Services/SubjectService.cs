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
            QuestionsBases = dto.QuestionsBases?.Select(x => new QuestionsBase()
            {
                Id = x.Id,
                SubjectId = x.SubjectId
            }).ToList()
        };

        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();
        
        return TransformToDto(subject);
    }
    
    public async Task<SubjectDto> GetByIdAsync(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);

        if (subject == null)
            throw new NullReferenceException("Сущность не найдена");

        return TransformToDto(subject);
    }
    
    // Read
    public async Task<ICollection<SubjectDto>> GetAllAsync()
    {
        return await _context.Subjects
            .Select(subject => TransformToDto(subject))
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

        return TransformToDto(subject);
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

    private static SubjectDto TransformToDto(Subject subject)
    {
        return new SubjectDto()
        {
            Id = subject.Id,
            Name = subject.Name,
            QuestionsBases = subject.QuestionsBases?.Select(x => new QuestionsBaseDto()
            {
                Id = x.Id,
                SubjectId = x.SubjectId
            }).ToList()
        };
    }
}