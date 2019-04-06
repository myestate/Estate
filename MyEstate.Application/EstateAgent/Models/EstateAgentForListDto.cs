using System;
using System.Collections.Generic;

namespace MyEstate.Application.EstateAgent.Models
{
    public class EstateAgentForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; } 
        public string PhotoUrl { get; set; } 
    }
}