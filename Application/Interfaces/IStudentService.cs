using Application.Dtos;
using HackTest.Entities;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<StudentDto> CreateAsync(StudentDto model);
}