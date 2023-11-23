using Application.Dtos;

namespace Application.Interfaces;

public interface IService<T> where T: BaseDto
{
    Task<T> GetByIdAsync(int id);
    Task<ICollection<T>> GetAllAsync();
    Task<T> CreateAsync(T dto);
    Task<T> UpdateAsync(T dto);
    Task DeleteAsync(int id);

}