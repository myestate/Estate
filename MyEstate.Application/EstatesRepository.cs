using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using MyEstate.Domain.Entities;
using Persistence;

namespace MyEstate.Application
{
    class EstatesRepository : IEstatesRepository
    {
        private readonly DataContext _context;
        public EstatesRepository(DataContext context)
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

        public async Task<Domain.Entities.Estate> GetEstate(int id)
        {
            var estate = await _context.Estates.Include(p => p.Photos).Include(p => p.Owner)
                             .FirstOrDefaultAsync(u => u.Id == id);

            return estate;
        }

        public async Task<IEnumerable<Domain.Entities.Estate>> GetEstates()
        {
            var estates = await _context.Estates.Include(p => p.Photos).Include(p => p.Owner).ToListAsync();

            return estates;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
