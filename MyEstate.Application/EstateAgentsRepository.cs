using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using MyEstate.Domain.Entities;
using Persistence;

namespace MyEstate.Application
{
    public class EstateAgentsRepository : IEstateAgentsRepository
    {
        private readonly MyEstateContext _context;
        public EstateAgentsRepository(MyEstateContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        public async Task<Domain.Entities.EstateAgent> GetEstateAgent(int id)
        {
            var estateAgent = await _context.EstateAgents.Include(p => p.Photos)
                             .FirstOrDefaultAsync(u => u.Id == id);

            return estateAgent;
        }

        public async Task<IEnumerable<Domain.Entities.EstateAgent>> GetEstateAgents()
        {
            var estateAgents = await _context.EstateAgents.Include(p => p.Photos).ToListAsync();

            return estateAgents;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Domain.Entities.EstateAgent> AddEstateAgent(Domain.Entities.EstateAgent estateAgent)
        {

            await _context.EstateAgents.AddAsync(estateAgent);
            await _context.SaveChangesAsync();

            return estateAgent;
        }
    }
}