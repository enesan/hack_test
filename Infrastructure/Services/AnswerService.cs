using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using HackTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AnswerService : IAnswerService
{
    private readonly IApplicationDbContext _context;

    public AnswerService(IApplicationDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<AnswerDto> CreateAsync(AnswerDto dto)
    {
        var answer = new Answer
        {
            Text = dto.Text,
            IsRight = dto.IsRight,
            QuestionId = dto.QuestionId
        };

        await _context.Answers.AddAsync(answer);
        await _context.SaveChangesAsync();
        
        return TransformToDto(answer);
    }

    public async Task<AnswerDto> GetByIdAsync(int id)
    {
        var answer = await _context.Answers.FindAsync(id);

        if (answer == null)
            throw new NullReferenceException("Сущность не найдена");

        return TransformToDto(answer);
    }

    // Read
    public async Task<ICollection<AnswerDto>> GetAllAsync()
    {
        return await _context.Answers
            .Select(answer => TransformToDto(answer))
            .ToListAsync();
    }

    // Update
    public async Task<AnswerDto> UpdateAsync(AnswerDto dto)
    {
        var answer = await _context.Answers.FindAsync(dto.Id);

        if (answer == null)
            throw new NullReferenceException("Сущность не найдена");

        answer.Text = dto.Text;
        answer.IsRight = dto.IsRight;
        answer.QuestionId = dto.QuestionId;

        _context.Answers.Update(answer);
        await _context.SaveChangesAsync();

        return TransformToDto(answer);
    }

    // Delete
    public async Task DeleteAsync(int id)
    {
        var answer = await _context.Answers.FindAsync(id);

        if (answer == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.Answers.Remove(answer);
        await _context.SaveChangesAsync();
    }

    private AnswerDto TransformToDto(Answer answer)
    {
        return new AnswerDto
        {
            Id = answer.Id,
            Text = answer.Text,
            IsRight = answer.IsRight,
            QuestionId = answer.QuestionId
        };
    }
    
}