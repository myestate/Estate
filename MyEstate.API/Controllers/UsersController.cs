using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEstate.Application.Interfaces;
using MyEstate.Application.User.Models;
using MyEstate.Domain.Entities;

namespace MyEstate.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetUsers()
        // {
        //     var users = await _repo.GetUsers();

        //     var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

        //     return Ok(usersToReturn);
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForDetailedDto userforUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(id);

            _mapper.Map(userforUpdateDto, userFromRepo);

            if(await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpGet]
        // [Route("api/users/getuserinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var re = Request;
            Microsoft.Extensions.Primitives.StringValues values;
            bool result = re.Headers.TryGetValue("Authorization", out values);
            if (result && values.Count > 0)
            {
                var token = values.SingleOrDefault();
                var  splitToken= token.Split(' ');
                var stream = "[encoded jwt]";
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(splitToken[1]) as JwtSecurityToken;
                var jti = tokenS.Claims.First(claim => claim.Type == "jti").Value;
                // var key = Encoding.ASCII.GetBytes(splitToken[1]);
                var tokenHandler = new JwtSecurityTokenHandler();

                var decodeToken = tokenHandler.ReadJwtToken(splitToken[1]);
                //Find user by id
                var userFromRepo = await _repo.GetUser(Convert.ToInt32(decodeToken.Id));

                var userDTO = _mapper.Map<UserForDetailedDto>(userFromRepo);
                return Ok(userDTO);
            }

            return Unauthorized();
        }
    }
}
