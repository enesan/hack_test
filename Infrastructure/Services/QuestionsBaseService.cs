using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class QuestionsBaseService : IQuestionsBaseService
{
    private readonly IApplicationDbContext _context;
    
    public QuestionsBaseService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<QuestionsBaseDto> CreateAsync(QuestionsBaseDto dto)
    {
        var questionsBase = new QuestionsBase
        {
            SubjectId = dto.SubjectId
        };

        await _context.QuestionsBases.AddAsync(questionsBase);
        await _context.SaveChangesAsync();
        
        return new QuestionsBaseDto()
        {
            Id = questionsBase.Id,
            SubjectId = questionsBase.SubjectId
        };
    }
    
    public async Task<QuestionsBaseDto> GetByIdAsync(int id)
    {
        var questionsBase = await _context.QuestionsBases.FindAsync(id);

        if (questionsBase == null)
            throw new NullReferenceException("Сущность не найдена");

        return new QuestionsBaseDto
        {
            Id = questionsBase.Id,
            SubjectId = questionsBase.SubjectId
        };
    }
    
    // Read
    public async Task<ICollection<QuestionsBaseDto>> GetAllAsync()
    {
        return await _context.QuestionsBases
            .Select(questionsBase => new QuestionsBaseDto
            {
                Id = questionsBase.Id,
                SubjectId = questionsBase.SubjectId
            })
            .ToListAsync();
    }
    
    // Update
    public async Task<QuestionsBaseDto> UpdateAsync(QuestionsBaseDto dto)
    {
        var questionsBase = await _context.QuestionsBases.FindAsync(dto.Id);

        if (questionsBase == null)
            throw new NullReferenceException("Сущность не найдена");

        questionsBase.SubjectId = dto.SubjectId;

        _context.QuestionsBases.Update(questionsBase);
        await _context.SaveChangesAsync();
        
        return new QuestionsBaseDto
        {
            Id = questionsBase.Id,
            SubjectId = questionsBase.SubjectId
        };
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var questionsBase = await _context.QuestionsBases.FindAsync(id);

        if (questionsBase == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.QuestionsBases.Remove(questionsBase);
        await _context.SaveChangesAsync();
    }
}