using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ElghoolHotel.API.Models;
using ElghoolHotel.API.Core.DTO;
using ElghoolHotel.API.Core.Contract.Repository;
using ElghoolHotel.API.Core.Helpers;

namespace ElghoolHotel.API.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        AppDbContext context;
        public BaseRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<Result<T>> GetByIdAsync(int id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result == null)
                return new Result<T>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.NotFound };

            return new Result<T>() { IsCompleteSuccessfully = true, Data = result };
        }

        public async Task<Result<List<T>>> GetWhereAsync(Expression<Func<T, bool>> criteria)
        {
            var result = await context.Set<T>().Where(criteria).ToListAsync();
            if (result.Count == 0)
                return new Result<List<T>>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.NotFound };

            return new Result<List<T>>() { IsCompleteSuccessfully = true, Data =  result };
        }

        public async Task<Result<List<T>>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();

            if (result.Count == 0)
                return new Result<List<T>>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.NotFound };

            return new Result<List<T>>() { IsCompleteSuccessfully = true, Data = result };
        }

        public async Task<Result<T>> DeleteAsync(int id)
        {
            if (id == 0)
                return new Result<T>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.IncorrectInput };

            Result<T> old = await GetByIdAsync(id);

            if (!old.IsCompleteSuccessfully)
                return new Result<T>() { IsCompleteSuccessfully = false , ErrorMessages = ErrorMessageUserConst.NotFound };

            try
            {
                context.Set<T>().Remove(old.Data);
                
                return new Result<T>() { IsCompleteSuccessfully = true, Data = old.Data };

            }
            catch (Exception ex)
            {
                return new Result<T>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.Unexpected };
            }

        }

        public async Task<Result<T>> EditAsync(T item)
        {

            if (item == null)
                return new Result<T>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.IncorrectInput };

            try
            {
                context.Set<T>().Update(item);
                
                return new Result<T>() { IsCompleteSuccessfully = true, Data = item };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Result<T>() { IsCompleteSuccessfully = false, Data = item, ErrorMessages = ErrorMessageUserConst.Unexpected };
            }
        }

        public async Task<Result<T>> InsertAsync(T item)
        {
            if (item == null)
                return new Result<T>() { IsCompleteSuccessfully = false, ErrorMessages = ErrorMessageUserConst.IncorrectInput };

            try
            {
                await context.Set<T>().AddAsync(item);
                
                return new Result<T>() { IsCompleteSuccessfully = true, Data = item };
            }
            catch (Exception)
            {
                return new Result<T>() { IsCompleteSuccessfully = false, Data = item, ErrorMessages = ErrorMessageUserConst.Unexpected };
            }
        }

    }
}
