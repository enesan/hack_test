using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            SubjectId = dto.SubjectId,
            Tests = dto.Tests?.Select(x => new Test()
            {
                Id = x.Id,
                QuestionsBaseId = x.QuestionsBaseId
            }).ToList(),
            QuestionsGroups = dto.QuestionsGroups?.Select(x => new QuestionsGroup()
            {
                Id = x.Id,
                Topic = x.Topic,
                QuestionsId = x.QuestionsId,
                QuestionsBaseId = x.QuestionsBaseId
            }).ToList()
        };

        await _context.QuestionsBases.AddAsync(questionsBase);
        await _context.SaveChangesAsync();

        return TransformToDto(questionsBase);
    }
    
    public async Task<QuestionsBaseDto> GetByIdAsync(int id)
    {
        var questionsBase = await _context.QuestionsBases.FindAsync(id);

        if (questionsBase == null)
            throw new NullReferenceException("Сущность не найдена");

        return TransformToDto(questionsBase);
    }
    
    // Read
    public async Task<ICollection<QuestionsBaseDto>> GetAllAsync()
    {
        return await _context.QuestionsBases
            .Select(questionsBase => TransformToDto(questionsBase))
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

        return TransformToDto(questionsBase);
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

    private static QuestionsBaseDto TransformToDto(QuestionsBase questionsBase)
    {
        return new QuestionsBaseDto()
        {
            SubjectId = questionsBase.SubjectId,
            Tests = questionsBase.Tests?.Select(x => new TestDto()
            {
                Id = x.Id,
                QuestionsBaseId = x.QuestionsBaseId
            }).ToList(),
            QuestionsGroups = questionsBase.QuestionsGroups?.Select(x => new QuestionsGroupDto()
            {
                Id = x.Id,
                Topic = x.Topic,
                QuestionsId = x.QuestionsId,
                QuestionsBaseId = x.QuestionsBaseId
            }).ToList()
        };
    }
}