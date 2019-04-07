using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEstate.Application.Interfaces;
using MyEstate.Application.EstateAgent.Models;
using MyEstate.Domain.Entities;

namespace MyEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentsController : ControllerBase
    {
        private readonly IEstateAgentsRepository _repo;
        public EstateAgentsController(IEstateAgentsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstateAgents()
        {
            var estateAgents = await _repo.GetEstateAgents();

            return Ok(estateAgents);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstateAgent(int id)
        {
            var estateAgent = await _repo.GetEstateAgent(id);

             return Ok(estateAgent);
        }

        [HttpPost]
        public async Task<IActionResult> AddEstateAgent([FromBody]EstateAgentForAddDto estateAgent)
        {
            var estateAgentToCreate = new EstateAgent
            {
                Name = estateAgent.Name,
                Gender = estateAgent.Gender,
                Age = estateAgent.Age,
                Login = estateAgent.Login,                
                LastActive = estateAgent.LastActive,
                City = estateAgent.City     
       
            };

            var creatEstateAgent = await _repo.AddEstateAgent(estateAgentToCreate);

            return StatusCode(201);
        }
    }
}