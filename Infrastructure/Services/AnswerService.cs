using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using HackTest.Entities;

namespace Infrastructure.Services;

public class AnswerService
{
    private readonly IApplicationDbContext _context;

    public AnswerService(IApplicationDbContext context)
    {
        _context = context;
    }

    // Create
    public void AddAnswer(AnswerDto answerDTO)
    {
        var answer = new Answer
        {
          
        };

        _context.Answers.Add(answer);
        _context.SaveChanges();
    }

    // Read
    public List<AnswerDto> GetAllAnswers()
    {
        return _context.Answers
            .Select(answer => new AnswerDto
            {
                Id = answer.Id,
                Content = answer.Content,
                // Map other properties if needed
            })
            .ToList();
    }

    public AnswerDTO GetAnswerById(int id)
    {
        var answer = _context.Answers.Find(id);

        if (answer == null)
        {
            // Handle not found
            return null;
        }

        return new AnswerDTO
        {
            Id = answer.Id,
            Content = answer.Content,
            // Map other properties if needed
        };
    }

    // Update
    public void UpdateAnswer(int id, AnswerDTO updatedAnswerDTO)
    {
        var answer = _context.Answers.Find(id);

        if (answer == null)
        {
            // Handle not found
            return;
        }

        answer.Content = updatedAnswerDTO.Content;
        // Update other properties if needed

        _context.SaveChanges();
    }

    // Delete
    public void DeleteAnswer(int id)
    {
        var answer = _context.Answers.Find(id);

        if (answer == null)
        {
            // Handle not found
            return;
        }

        _context.Answers.Remove(answer);
        _context.SaveChanges();
    }

}