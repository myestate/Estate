using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.Helpers;

namespace MyEstate.Application.Interfaces
{
    public interface IDatingRepository
    {
        void Add<T>(T entry) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<MyEstate.Domain.Entities.User>> GetUsers();
        Task<MyEstate.Domain.Entities.User> GetUser(int id);

        Task<MyEstate.Domain.Entities.Photo> GetPhoto(int id); 
        Task<bool> UpdateUser(Domain.Entities.User user);

        Task<MyEstate.Domain.Entities.Message> GetMessage(int id);

        Task<PagedList<Domain.Entities.Message>> GetMessagesForUser();

        Task<IEnumerable<Domain.Entities.Message>> GetMessageThread(int userId, int recipientId);
    }
}