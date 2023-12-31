﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using redimel_server.CustomActionFilters;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorsController : ControllerBase
    {
        private readonly IIndicatorRepository indicatorRepository;
        private readonly IMapper mapper;

        public IndicatorsController(IIndicatorRepository indicatorRepository, IMapper mapper)
        {
            this.indicatorRepository = indicatorRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAll()
        {
            //logger.LogInformation("GetAll method was invoked!");

            //logger.LogWarning("This is a warning log!");
            //logger.LogError("This is a error log!");

            //var indicatorDto = new List<IndicatorDto>();
            //foreach (var indicator in indicatorDomain)
            //{
            //    indicatorDto.Add(new IndicatorDto()
            //    {
            //        Id = indicator.Id,
            //        Health = indicator.Health,
            //        MentalEnergy = indicator.MentalEnergy,
            //        MentalStrength = indicator.MentalStrength,
            //        Strength = indicator.Strength,
            //        Dexterity = indicator.Dexterity,
            //        Agility = indicator.Agility,
            //        Evasion = indicator.Evasion,
            //        Endurance = indicator.Endurance
            //    });
            //}
            
            //string userName = Request.HttpContext.User.Identity.Name;

            var indicatorDomain = await indicatorRepository.GetAllAsync();
            
            //logger.LogInformation($"Finished GetAllIndicators request with data {JsonSerializer.Serialize(indicatorDomain)}");

            //Map Domain Models to DTOs
            var indicatorDto = mapper.Map<List<IndicatorDto>>(indicatorDomain);
            
            //throw new Exception("this is a random exception!!!");

            //return DTO
            return Ok(indicatorDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var indicatorDomain = await indicatorRepository.GetByIdAsync(id);
            
            //var indicatorDomain = await dbContext.Indicators.FindAsync(id);
            //var indicator = dbContext.Indicators.FirstOrDefaultAsync(x => x.Id == id);

            if (indicatorDomain == null)
            {
                return NotFound();
            }

            //var indicatorDto = new IndicatorDto
            //{
            //    Id = indicatorDomain.Id,
            //    Health = indicatorDomain.Health,
            //    MentalEnergy = indicatorDomain.MentalEnergy,
            //    MentalStrength = indicatorDomain.MentalStrength,
            //    Strength = indicatorDomain.Strength,
            //    Dexterity = indicatorDomain.Dexterity,
            //    Agility = indicatorDomain.Agility,
            //    Evasion = indicatorDomain.Evasion,
            //    Endurance = indicatorDomain.Endurance
            //};

            var indicatorDto = mapper.Map<IndicatorDto>(indicatorDomain);

            return Ok(indicatorDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddIndicatorRequestDto addIndicatorRequestDto)
        {
            var indicatorDomainModel = mapper.Map<Indicator>(addIndicatorRequestDto);

            indicatorDomainModel = await indicatorRepository.CreateAsync(indicatorDomainModel);

            var indicatorDto = mapper.Map<IndicatorDto>(indicatorDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = indicatorDto.Id }, indicatorDto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIndicatorRequestDto updateIndicatorRequestDto)
        {
            var indicatorDomainModel = mapper.Map<Indicator>(updateIndicatorRequestDto);

            indicatorDomainModel = await indicatorRepository.UpdateAsync(id, indicatorDomainModel);

            if (indicatorDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IndicatorDto>(indicatorDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var indicatorDomainModel = await indicatorRepository.DeleteAsync(id);

            if (indicatorDomainModel == null)
            {
                return NotFound();
            }

            //return deleted Indicator back - optional
            return Ok();
        }
    }
}
