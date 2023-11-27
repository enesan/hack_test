using System.Linq;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using HackTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UniversityService : IUniversityService
{
    private readonly IApplicationDbContext _context;
    
    public UniversityService(IApplicationDbContext context)
    {
        _context = context;
    }
    
    // Create
    public async Task<UniversityDto> CreateAsync(UniversityDto dto)
    {
        var university = new University
        {
            Name = dto.Name,
            Students = dto.Students?.Select(x => new Student()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                GroupId = x.GroupId,
                UniversityId = x.UniversityId
            }).ToList()
        };

        await _context.Universities.AddAsync(university);
        await _context.SaveChangesAsync();
        
        return TransformToDto(university);
    }
    
    public async Task<UniversityDto> GetByIdAsync(int id)
    {
        var university = await _context.Universities.FindAsync(id);

        if (university == null)
            throw new NullReferenceException("Сущность не найдена");

        return TransformToDto(university);
    }
    
    // Read
    public async Task<ICollection<UniversityDto>> GetAllAsync()
    {
        return await _context.Universities
            .Select(university => TransformToDto(university))
            .ToListAsync();
    }
    
    // Update
    public async Task<UniversityDto> UpdateAsync(UniversityDto dto)
    {
        var university = await _context.Universities.FindAsync(dto.Id);

        if (university == null)
            throw new NullReferenceException("Сущность не найдена");

        university.Name = dto.Name;

        _context.Universities.Update(university);
        await _context.SaveChangesAsync();

        return TransformToDto(university);
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var university = await _context.Universities.FindAsync(id);

        if (university == null)
            throw new NullReferenceException("Сущность не найдена");

        _context.Universities.Remove(university);
        await _context.SaveChangesAsync();
    }

    private static UniversityDto TransformToDto(University university)
    {
        return new UniversityDto()
        {
            Id = university.Id,
            Name = university.Name,
            Students = university.Students?.Select(x => new StudentDto()
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