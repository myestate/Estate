using Persistence.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEstate.Application.Interfaces
{
    public interface IEstatesRepository
    {
        void Add<T>(T entry) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<Domain.Entities.Estate>> GetEstates(EstateParams estateParams);
        Task<Domain.Entities.Estate> GetEstate(int userId);
        Task<Domain.Entities.Estate> GetEstateByOwnerId(int userId);
        Task<Domain.Entities.Estate> AddEstate(Domain.Entities.Estate estate);

        Task<IEnumerable<Domain.Entities.Estate>> GetAllEstates();
    }
}
