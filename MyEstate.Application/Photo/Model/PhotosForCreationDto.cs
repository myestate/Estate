using System;
using Microsoft.AspNetCore.Http;

namespace MyEstate.Application.Photo.Model
{
    public class PhotoForCreationDto
    {
        public string Url{get;set;}

        public IFormFile File{get;set;}

        public string Description{get;set;}

        public DateTime DateAddded {get;set;}

        public string PublicId {get;set;}

        public PhotoForCreationDto()
        {
            DateAddded = DateTime.Now;
        }
    }
} 