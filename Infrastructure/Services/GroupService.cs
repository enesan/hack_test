using System.Runtime.Intrinsics.X86;
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
            Number = model.Number,
            Students = model.Students?.Select(x => new Student()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                GroupId = x.GroupId,
                UniversityId = x.UniversityId
            }).ToList()
        };

        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();

        return TransformToDto(group);
    }
    public async Task<GroupDto> GetByIdAsync(int id)
    {
        var group = await _context.Groups.FindAsync(id);

        if (group == null)
            throw new NullReferenceException("Сущность не найдена");

        return TransformToDto(group);
    }
    
    // Read
    public async Task<ICollection<GroupDto>> GetAllAsync()
    {
        return await _context.Groups
            .Select(group => TransformToDto(group))
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

        return TransformToDto(group);
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

    private GroupDto TransformToDto(Group group)
    {
        return new GroupDto()
        {
            Id = group.Id,
            Number = group.Number,
            Students = group.Students?.Select(x => new StudentDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                GroupId = x.GroupId,
                UniversityId = x.UniversityId
            }).ToList()
        };
    }
}