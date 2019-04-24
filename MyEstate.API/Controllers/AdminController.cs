﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEstate.Application.RoleEdit;
using Microsoft.AspNetCore.Identity;
using MyEstate.Domain.Entities;

namespace MyEstate.API.Controllers
{
    [ApiController]
    [Route("api/controller")]

    public class AdminController : ControllerBase
    {
        private readonly MyEstateContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(MyEstateContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("userWhithRoles")]

        public async Task<IActionResult> GetUserWithRoles()
        {
            var userList = await (from user in _context.Users
                                  orderby user.UserName
                                  select new
                                  {
                                      Id = user.Id,
                                      UserName = user.UserName,
                                      Roles = (from userRole in user.UserRoles
                                               join role in _context.Roles
                                               on userRole.RoleId
                                               equals role.Id
                                               select role.Name).ToList()
                                  }).ToListAsync();


            return Ok(userList);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("editRole/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var userRoles = await _userManager.GetRolesAsync(user);

            var selectedRoles = roleEditDto.RoleNames;
            
            selectedRoles = selectedRoles ?? new string[] { };

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded)
                return BadRequest("Failed to add to roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded)
                return BadRequest("Failed to add to roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photosForModeration")]
        public IActionResult GetPhotosForModeration()
        {
            return Ok("Admins or moderators can see this");
        }
    }
}
