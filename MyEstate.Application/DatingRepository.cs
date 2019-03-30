using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using MyEstate.Domain.Entities;
using Persistence;

namespace MyEstate.Application
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
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

        public async Task<Domain.Entities.User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos)
                             .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<Domain.Entities.User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}