using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.Interfaces;
using MyEstate.Domain.Entities;
using Persistence;
using Persistence.Helpers;

namespace MyEstate.Application
{
    public class EstatesRepository : IEstatesRepository
    {
        private readonly MyEstateContext _context;
        public EstatesRepository(MyEstateContext context)
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
            var estate = await _context.Estates.Include(p => p.Photos)
                             .LastOrDefaultAsync(u => u.Id == id);

            return estate;
        }

        public async Task<PagedList<Domain.Entities.Estate>> GetEstates(EstateParams estateParams)
        {
            var estates = _context.Estates.Include(p => p.Photos).OrderByDescending(e => e.Created).AsQueryable();

            if (!string.IsNullOrEmpty(estateParams.Type) && estateParams.Type != "All")
            {
                estates = estates.Where(e => e.AdType == estateParams.Type);
            }

            if (!string.IsNullOrEmpty(estateParams.Country) && estateParams.Country != "All")
            {
                estates = estates.Where(e => e.Country == estateParams.Country);
            }

            if (!string.IsNullOrEmpty(estateParams.City) && estateParams.City != "All")
            {
                estates = estates.Where(e => e.City == estateParams.City);
            }

            if (!string.IsNullOrEmpty(estateParams.Street) && estateParams.Street != "All")
            {
                estates = estates.Where(e => e.Street == estateParams.Street);
            }

            if (estateParams.OwnerId != -1)
            {
                estates = estates.Where(e => e.OwnerId == estateParams.OwnerId);
            }

            if (estateParams.MinPrice != 0 || estateParams.MaxPrice != 5000000)
            {
                estates = estates.Where(e => e.Price>= estateParams.MinPrice && e.Price<= estateParams.MaxPrice);
            }

            if (estateParams.MinSquare != 0 || estateParams.MaxSquare != 1000)
            {
                estates = estates.Where(e => e.Square >= estateParams.MinSquare && e.Square <= estateParams.MaxSquare);
            }

            if (estateParams.MinRooms != 1 || estateParams.MaxRooms != 10)
            {
                estates = estates.Where(e => e.Rooms >= estateParams.MinRooms && e.Rooms <= estateParams.MaxRooms);
            }

            if (estateParams.MinFloors != 1 || estateParams.MaxFloors != 10)
            {
                estates = estates.Where(e => e.Floors >= estateParams.MinFloors && e.Floors <= estateParams.MaxFloors);
            }

            if (!string.IsNullOrEmpty(estateParams.OrderBy))
            {
                switch (estateParams.OrderBy)
                {
                    case "priceUp":
                        {
                            estates = estates.OrderBy(e => e.Price);
                            break;
                        };
                    case "priceDown":
                        {
                            estates = estates.OrderByDescending(e => e.Price);
                            break;
                        };
                    case "squareUp":
                        {
                            estates = estates.OrderBy(e => e.Square);
                            break;
                        };
                    case "squareDown":
                        {
                            estates = estates.OrderByDescending(e => e.Square);
                            break;
                        };
                    case "roomsUp":
                        {
                            estates = estates.OrderBy(e => e.Rooms);
                            break;
                        };
                    case "roomsDown":
                        {
                            estates = estates.OrderByDescending(e => e.Rooms);
                            break;
                        };
                    default:
                        {
                            estates = estates.OrderByDescending(e => e.Created);
                            break;
                        }
                }
            }

            return await PagedList< Domain.Entities.Estate>.CreateAsync(estates, estateParams.PageNumber, estateParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Domain.Entities.Estate> AddEstate(Domain.Entities.Estate estate)
        {

            await _context.Estates.AddAsync(estate);
            await _context.SaveChangesAsync();

            return estate;
        }

        public async Task<IEnumerable<Domain.Entities.Estate>> GetAllEstates()
        {
            var estates = await _context.Estates.Include(p => p.Photos).ToListAsync();

            return estates;
        }
    }
}
