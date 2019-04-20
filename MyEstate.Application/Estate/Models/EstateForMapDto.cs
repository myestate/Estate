using System.Collections.Generic;
using MyEstate.Application.Photo.Model;
using MyEstate.Application.User.Models;

namespace MyEstate.Application.Estate.Models
{
    public class EstateForMapDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public UserForListDto Owner { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
         public ICollection<PhotosForDetailedDto> Photos { get; set; }
    }
}