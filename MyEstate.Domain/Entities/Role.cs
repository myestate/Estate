using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace MyEstate.Domain.Entities
{
    public class Role :IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
