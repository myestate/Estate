using System;
using System.Collections.Generic;
using MyEstate.Application.Photo.Model;
using MyEstate.Application.User.Models;
using MyEstate.Domain.Entities;

namespace MyEstate.Application.Estate.Models
{
    public class EstateForListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public UserForListDto Owner { get; set; }
        public double Square { get; set; }
        public int Rooms { get; set; }
        public int Floors { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ICollection<PhotosForDetailedDto> Photos { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
    }
}
