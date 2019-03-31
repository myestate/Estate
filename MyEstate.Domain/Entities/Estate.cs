using System;
using System.Collections.Generic;

namespace MyEstate.Domain.Entities
{
    public class Estate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public User Owner { get; set; }
        public double Square { get; set; }
        public int Rooms { get; set; }
        public int Floors { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
    }
}
