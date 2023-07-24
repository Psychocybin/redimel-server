﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWeaponRepository weaponRepository;

        public WeaponsController(IMapper mapper, IWeaponRepository weaponRepository)
        {
            this.mapper = mapper;
            this.weaponRepository = weaponRepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var weaponDomain = await weaponRepository.GetByIdAsync(id);

            if (weaponDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WeaponDto>(weaponDomain));
        }
    }
}