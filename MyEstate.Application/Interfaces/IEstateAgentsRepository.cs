using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEstate.Application.Interfaces
{
    public interface IEstateAgentsRepository
    {
        void Add<T>(T entry) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<MyEstate.Domain.Entities.EstateAgent>> GetEstateAgents();
        Task<MyEstate.Domain.Entities.EstateAgent> GetEstateAgent(int id);
        Task<Domain.Entities.EstateAgent> AddEstateAgent(Domain.Entities.EstateAgent estateAgent);
    }
}