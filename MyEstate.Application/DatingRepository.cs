using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using Persistence.Helpers;
using Persistence;

namespace MyEstate.Application
{
    public class DatingRepository : IDatingRepository
    {
        private readonly MyEstateContext _context;

        public DatingRepository(MyEstateContext context)
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

        public async Task<Domain.Entities.Message> GetMessage(int id)
        {
           return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Domain.Entities.Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages.Include(u => u.Sender).ThenInclude(p => p.Photos)
            .Include( u => u.Recipient).ThenInclude(p => p.Photos)
            .AsQueryable();

            switch(messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u=> u.RecipientId == messageParams.UserId
                     && u.RecipientDeleted == false);
                    break;
                case "Outbox": 
                    messages = messages.Where(u=> u.SenderId == messageParams.UserId
                     && u.SenderDeleted == false);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId
                     && u.RecipientDeleted == false && u.IsRead == false);
                    break;
            }

            messages = messages.OrderByDescending(d => d.MessageSent);
            return await PagedList<Domain.Entities.Message>.CreateAsync(messages,
            messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Domain.Entities.Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages.Include(u => u.Sender).ThenInclude(p => p.Photos)
            .Include( u => u.Recipient).ThenInclude(p => p.Photos)
            .Where(m => m.RecipientId == userId && m.RecipientDeleted == false && m.SenderId == recipientId
             || m.RecipientId == recipientId && m.SenderId == userId
             && m.SenderDeleted == false)
             .OrderByDescending(m => m.MessageSent)
             .ToListAsync();

             return messages;
        }

        public async Task<EstatePhoto> GetPhoto(int id)
        {
            var photo = await _context.EstatePhotos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<Domain.Entities.User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<Domain.Entities.User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(Domain.Entities.User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}