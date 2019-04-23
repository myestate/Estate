using System;
using System.Collections.Generic;
using System.Text;

namespace MyEstate.Application.User.Models
{
    public class UserForChangePasswordDto
    {
        public string oldPass { get; set; }

        public string newPass { get; set; }
    }
}
