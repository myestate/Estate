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
using System.Text;

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

        [HttpGet]
        [Route("/api/users/getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody]UserForDetailedDto userForUpdateDto)
        {
            if (id != userForUpdateDto.Id)
            {
                return BadRequest();
            }

            var userFromRepo = await _repo.GetUser(id);
            userFromRepo.Username = userForUpdateDto.Username;
            userFromRepo.City = userForUpdateDto.City;
            userFromRepo.Country = userForUpdateDto.Country;
            //var user = _mapper.Map<User>(userForUpdateDto);
            var temp = await _repo.UpdateUser(userFromRepo);
            if(temp)
            {
                return Ok(await _repo.GetUser(id));
            }else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserPassword([FromBody]UserForChangePasswordDto userForChangePassDto)
        {
            var re = Request;
            Microsoft.Extensions.Primitives.StringValues values;
            bool result = re.Headers.TryGetValue("Authorization", out values);
            if (result && values.Count > 0)
            {
                var token = values.SingleOrDefault();
                var splitToken = token.Split(' ');
                var tokenHandler = new JwtSecurityTokenHandler();

                var jsonToken = tokenHandler.ReadJwtToken(splitToken[1]) as JwtSecurityToken;
                //Find user by id
                string id = jsonToken.Payload.ContainsKey("nameid") ? jsonToken.Payload["nameid"].ToString() : null;
                var userFromRepo = await _repo.GetUser(Convert.ToInt32(id));

                if (VerifyPasswordHash(userForChangePassDto.oldPass, userFromRepo.PasswordHash, userFromRepo.PasswordSalt))
                {
                    CreatePasswordHash(userForChangePassDto.newPass, out var passwordHash, out var passwordSalt);
                    userFromRepo.PasswordHash = passwordHash;
                    userFromRepo.PasswordSalt = passwordSalt;

                    var temp = await _repo.UpdateUser(userFromRepo);
                    if(temp)
                    {
                        return Ok(await _repo.GetUser(Convert.ToInt32(id)));
                    }else
                    {
                        return BadRequest();
                    }
                }else{
                    return BadRequest();
                }

            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("/api/users/getuserinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var re = Request;
            Microsoft.Extensions.Primitives.StringValues values;
            bool result = re.Headers.TryGetValue("Authorization", out values);
            if (result && values.Count > 0)
            {
                var token = values.SingleOrDefault();
                var splitToken = token.Split(' ');
                var tokenHandler = new JwtSecurityTokenHandler();

                var jsonToken = tokenHandler.ReadJwtToken(splitToken[1]) as JwtSecurityToken;
                //Find user by id
                 string id = jsonToken.Payload.ContainsKey("nameid") ? jsonToken.Payload["nameid"].ToString() : null;
                var userFromRepo = await _repo.GetUser(Convert.ToInt32(id));

                var userDTO = _mapper.Map<UserForDetailedDto>(userFromRepo);
                return Ok(userDTO);
            }

            return Unauthorized();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                if (computedHash.Where((t, i) => t != passwordHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
