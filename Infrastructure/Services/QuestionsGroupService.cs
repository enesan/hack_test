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
        
        return new QuestionsGroupDto
        {
            Id = questionsGroup.Id,
            Topic = questionsGroup.Topic,
            QuestionsId = dto.QuestionsId,
            QuestionsBaseId = dto.QuestionsBaseId
        };
    }
    
    public async Task<QuestionsGroupDto> GetByIdAsync(int id)
    {
        var questionsGroup = await _context.QuestionsGroups.FindAsync(id);

        if (questionsGroup == null)
            throw new NullReferenceException("Сущность не найдена");

        return new QuestionsGroupDto
        {
            Id = questionsGroup.Id,
            Topic = questionsGroup.Topic,
            QuestionsId = questionsGroup.QuestionsId,
            QuestionsBaseId = questionsGroup.QuestionsBaseId
        };
    }
    
    // Read
    public async Task<ICollection<QuestionsGroupDto>> GetAllAsync()
    {
        return await _context.QuestionsGroups
            .Select(questionsGroup => new QuestionsGroupDto()
            {
                Id = questionsGroup.Id,
                Topic = questionsGroup.Topic,
                QuestionsId = questionsGroup.QuestionsId,
                QuestionsBaseId = questionsGroup.QuestionsBaseId
            })
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
        
        return new QuestionsGroupDto()
        {
            Id = questionsGroup.Id,
            Topic = questionsGroup.Topic,
            QuestionsId = questionsGroup.QuestionsId,
            QuestionsBaseId = questionsGroup.QuestionsBaseId
        };
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
}