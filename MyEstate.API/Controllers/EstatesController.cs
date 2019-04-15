using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEstate.Application.Interfaces;
using MyEstate.Application.Estate.Models;
using MyEstate.Domain.Entities;
using Persistence.Helpers;

namespace MyEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly IEstatesRepository _repo;
        private readonly IMapper _mapper;

        public EstatesController(IEstatesRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstates([FromQuery]EstateParams estateParams)
        {
            var estates = await _repo.GetEstates(estateParams);

            var estatesToReturn = _mapper.Map<IEnumerable<EstateForListDto>>(estates);

            Response.AddPagination(estates.CurrentPage, estates.PageSize, estates.TotalCount, estates.TotalPages);

            return Ok(estatesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstate(int id)
        {
            var estate = await _repo.GetEstate(id);

            var estateToReturn = _mapper.Map<EstateForListDto>(estate);

            return Ok(estateToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddEstate([FromBody]EstateForAddDto estate)
        {
            var estateToCreate = new Estate
            {
                Title = estate.Title,
                Description = estate.Description,
                Price = estate.Price,
                Square = estate.Square,
                Rooms = estate.Rooms,
                Floors = estate.Floors,
                Country = estate.Country,
                City = estate.City,
                Street = estate.Street,
                IsActive = estate.IsActive,
                Created = DateTime.Now
            };

            var creatEstate = await _repo.AddEstate(estateToCreate);

            return StatusCode(201);
        }
    }
}
