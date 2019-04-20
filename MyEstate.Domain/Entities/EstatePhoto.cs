using System;

namespace MyEstate.Domain.Entities
{
    public class EstatePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId{get;set;}
        public Estate Estate { get; set; }
        public int EstateId { get; set; }
    }
}