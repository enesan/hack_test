using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TestService : ITestService
{
    private readonly IApplicationDbContext _context;
    
    public TestService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<TestDto> CreateAsync(TestDto dto)
    {
        var test = new Test
        {
            QuestionsBaseId = dto.QuestionsBaseId
        };

        await _context.Tests.AddAsync(test);
        await _context.SaveChangesAsync();
        
        return new TestDto
        {
            Id = test.Id,
            QuestionsBaseId = test.QuestionsBaseId
        };
    }
    
    public async Task<TestDto> GetByIdAsync(int id)
    {
        var test = await _context.Tests.FindAsync(id);

        if (test == null)
            throw new NullReferenceException("Сущность не найдена");

        return new TestDto
        {
            Id = test.Id,
            QuestionsBaseId = test.QuestionsBaseId
        };
    }
    
    // Read
    public async Task<ICollection<TestDto>> GetAllAsync()
    {
        return await _context.Tests
            .Select(test => new TestDto
            {
                Id = test.Id,
                QuestionsBaseId = test.QuestionsBaseId
            })
            .ToListAsync();
    }
    
    // Update
    public async Task<TestDto> UpdateAsync(TestDto dto)
    {
        var test = await _context.Tests.FindAsync(dto.Id);

        if (test == null)
            throw new NullReferenceException("Сущность не найдена");

        test.QuestionsBaseId = dto.QuestionsBaseId;

        _context.Tests.Update(test);
        await _context.SaveChangesAsync();
        
        return new TestDto
        {
            Id = test.Id,
            QuestionsBaseId = test.QuestionsBaseId
        };
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var test = await _context.Tests.FindAsync(id);

        if (test == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.Tests.Remove(test);
        await _context.SaveChangesAsync();
    }
}