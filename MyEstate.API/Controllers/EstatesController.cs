using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEstate.Application.Interfaces;
using MyEstate.Application.User.Models;

namespace MyEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public EstatesController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstates()
        {
            var users = await _repo.GetUsers();

            var estatesToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(estatesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstate(int id)
        {
            var estate = await _repo.GetUser(id);

            var estateToReturn = _mapper.Map<UserForDetailedDto>(estate);

            return Ok(estateToReturn);
        }
    }
}
