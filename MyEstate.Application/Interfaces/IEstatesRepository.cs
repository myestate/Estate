using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEstate.Application.Interfaces
{
    public interface IEstatesRepository
    {
        void Add<T>(T entry) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<MyEstate.Domain.Entities.Estate>> GetEstates();
        Task<MyEstate.Domain.Entities.Estate> GetEstate(int id);
        Task<Domain.Entities.Estate> AddEstate(Domain.Entities.Estate estate);
    }
}
