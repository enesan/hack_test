using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class QuestionsGroupService : IQuestionsGroupService
{
    private readonly IApplicationDbContext _context;
    
    public QuestionsGroupService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<QuestionsGroupDto> CreateAsync(QuestionsGroupDto dto)
    {
        var questionsGroup = new QuestionsGroup
        {
            Topic = dto.Topic,
            QuestionsId = dto.QuestionsId,
            QuestionsBaseId = dto.QuestionsBaseId
        };

        await _context.QuestionsGroups.AddAsync(questionsGroup);
        await _context.SaveChangesAsync();
        
        return TransformToDto(questionsGroup);
    }
    
    public async Task<QuestionsGroupDto> GetByIdAsync(int id)
    {
        var questionsGroup = await _context.QuestionsGroups.FindAsync(id);

        if (questionsGroup == null)
            throw new NullReferenceException("Сущность не найдена");

        return TransformToDto(questionsGroup);
    }
    
    // Read
    public async Task<ICollection<QuestionsGroupDto>> GetAllAsync()
    {
        return await _context.QuestionsGroups
            .Select(questionsGroup => TransformToDto(questionsGroup))
            .ToListAsync();
    }
    
    // Update
    public async Task<QuestionsGroupDto> UpdateAsync(QuestionsGroupDto dto)
    {
        var questionsGroup = await _context.QuestionsGroups.FindAsync(dto.Id);

        if (questionsGroup == null)
            throw new NullReferenceException("Сущность не найдена");

        questionsGroup.Topic = dto.Topic;

        _context.QuestionsGroups.Update(questionsGroup);
        await _context.SaveChangesAsync();

        return TransformToDto(questionsGroup);
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var questionsGroup = await _context.QuestionsGroups.FindAsync(id);

        if (questionsGroup == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.QuestionsGroups.Remove(questionsGroup);
        await _context.SaveChangesAsync();
    }

    private QuestionsGroupDto TransformToDto(QuestionsGroup questionsGroup)
    {
        return new QuestionsGroupDto()
        {
            Id = questionsGroup.Id,
            Topic = questionsGroup.Topic,
            QuestionsId = questionsGroup.QuestionsId,
            QuestionsBaseId = questionsGroup.QuestionsBaseId
        };
    }
}