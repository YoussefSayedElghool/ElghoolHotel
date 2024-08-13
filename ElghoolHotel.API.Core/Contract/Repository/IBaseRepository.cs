
using System.Linq.Expressions;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Models;

namespace ElghoolHotel.API.Core.Contract.Repository;
public interface IBaseRepository<T> where T : class
{
    Task<Result<List<T>>> GetAllAsync();
    Task<Result<T>> GetByIdAsync(int id);
    Task<Result<List<T>>> GetWhereAsync(Expression<Func<T, bool>> criteria);
    Task<Result<T>> InsertAsync(T item);
    Task<Result<T>> EditAsync(T item);
    Task<Result<T>> DeleteAsync(int id);
}