using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class QuestionService : IQuestionService
{
    private readonly IApplicationDbContext _context;

    public QuestionService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<QuestionDto> CreateAsync(QuestionDto model)
    {
        var question = new Question
        {
            Text = model.Text,
            CommentRight = model.CommentRight,
            CommentWrong = model.CommentWrong,
        };

        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();

       return new QuestionDto()
       {
           Id = question.Id,
           Text = question.Text,
           CommentRight = question.CommentRight,
           CommentWrong = question.CommentWrong
       };

    }
    public async Task<QuestionDto> GetByIdAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);

        if (question == null)
            throw new NullReferenceException("Сущность не найдена");

        return new QuestionDto()
        {
            Id = question.Id,
            Text = question.Text,
            CommentRight = question.CommentRight,
            CommentWrong = question.CommentWrong
        };
    }
    
    // Read
    public async Task<ICollection<QuestionDto>> GetAllAsync()
    {
        return await _context.Questions
            .Select(question => new QuestionDto()
            {
                Id = question.Id,
                Text = question.Text,
                CommentRight = question.CommentRight,
                CommentWrong = question.CommentWrong
            })
            .ToListAsync();
    }
    
    // Update
    public async Task<QuestionDto> UpdateAsync(QuestionDto dto)
    {
        var question = await _context.Questions.FindAsync(dto.Id);

        if (question == null)
            throw new NullReferenceException("Сущность не найдена");

        question.Text = dto.Text;
        question.CommentRight = dto.CommentRight;
        question.CommentWrong = dto.CommentWrong;
        
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
        
        return new QuestionDto()
        {
            Id = question.Id,
            Text = question.Text,
            CommentRight = question.CommentRight,
            CommentWrong = question.CommentWrong
        };
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);

        if (question == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }
}