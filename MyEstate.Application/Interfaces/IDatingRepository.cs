using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEstate.Application.Interfaces
{
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<MyEstate.Domain.Entities.User>> GetUsers();
        Task<MyEstate.Domain.Entities.User> GetUser(int id);
    }
}