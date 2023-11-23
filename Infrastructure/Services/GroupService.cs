using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly IApplicationDbContext _context;

    public GroupService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<GroupDto> CreateAsync(GroupDto model)
    {
        var group = new Group
        {
            Number = model.Number
        };

        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();

       return new GroupDto
       {
           Id = group.Id,
           Number = group.Number
       };

    }
    public async Task<GroupDto> GetByIdAsync(int id)
    {
        var group = await _context.Groups.FindAsync(id);

        if (group == null)
            throw new NullReferenceException("Сущность не найдена");

        return new GroupDto
        {
            Id = group.Id,
            Number = group.Number
        };
    }
    
    // Read
    public async Task<ICollection<GroupDto>> GetAllAsync()
    {
        return await _context.Groups
            .Select(group => new GroupDto
            {
                Id = group.Id,
                Number = group.Number
            })
            .ToListAsync();
    }
    
    // Update
    public async Task<GroupDto> UpdateAsync(GroupDto dto)
    {
        var group = await _context.Groups.FindAsync(dto.Id);

        if (group == null)
            throw new NullReferenceException("Сущность не найдена");

        group.Number = dto.Number;
        
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
        
        return new GroupDto
        {
            Id = group.Id,
            Number = group.Number
        };
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var group = await _context.Groups.FindAsync(id);

        if (group == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
    }
}