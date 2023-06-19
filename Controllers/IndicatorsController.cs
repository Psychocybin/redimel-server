using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using redimel_server.Data;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;
using redimel_server.Repositories;
using System;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorsController : ControllerBase
    {
        private readonly IIndicatorRepository indicatorRepository;

        public IndicatorsController(IIndicatorRepository indicatorRepository)
        {
            this.indicatorRepository = indicatorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var indicatorDomain = await indicatorRepository.GetAllAsync();

            var indicatorDto = new List<IndicatorDto>();
            foreach (var indicator in indicatorDomain)
            {
                indicatorDto.Add(new IndicatorDto()
                {
                    Id = indicator.Id,
                    Health = indicator.Health,
                    MentalEnergy = indicator.MentalEnergy,
                    MentalStrength = indicator.MentalStrength,
                    Strength = indicator.Strength,
                    Dexterity = indicator.Dexterity,
                    Agility = indicator.Agility,
                    Evasion = indicator.Evasion,
                    Endurance = indicator.Endurance
                });
            }

            //return DTO
            return Ok(indicatorDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var indicatorDomain = await indicatorRepository.GetByIdAsync(id);
            
            //var indicatorDomain = await dbContext.Indicators.FindAsync(id);
            //var indicator = dbContext.Indicators.FirstOrDefaultAsync(x => x.Id == id);

            if (indicatorDomain == null)
            {
                return NotFound();
            }

            var indicatorDto = new IndicatorDto
            {
                Id = indicatorDomain.Id,
                Health = indicatorDomain.Health,
                MentalEnergy = indicatorDomain.MentalEnergy,
                MentalStrength = indicatorDomain.MentalStrength,
                Strength = indicatorDomain.Strength,
                Dexterity = indicatorDomain.Dexterity,
                Agility = indicatorDomain.Agility,
                Evasion = indicatorDomain.Evasion,
                Endurance = indicatorDomain.Endurance
            };

            return Ok(indicatorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddIndicatorRequestDto addIndicatorRequestDto)
        {
            var indicatorDomainModel = new Indicator
            {
                Health = addIndicatorRequestDto.Health,
                MentalEnergy = addIndicatorRequestDto.MentalEnergy,
                MentalStrength = addIndicatorRequestDto.MentalStrength,
                Strength = addIndicatorRequestDto.Strength,
                Dexterity = addIndicatorRequestDto.Dexterity,
                Agility = addIndicatorRequestDto.Agility,
                Evasion = addIndicatorRequestDto.Evasion,
                Endurance = addIndicatorRequestDto.Endurance
            };

            indicatorDomainModel = await indicatorRepository.CreateAsync(indicatorDomainModel);

            var indicatorDto = new IndicatorDto
            {
                Id = indicatorDomainModel.Id,
                Health = indicatorDomainModel.Health,
                MentalEnergy = indicatorDomainModel.MentalEnergy,
                MentalStrength = indicatorDomainModel.MentalStrength,
                Strength = indicatorDomainModel.Strength,
                Dexterity = indicatorDomainModel.Dexterity,
                Agility = indicatorDomainModel.Agility,
                Evasion = indicatorDomainModel.Evasion,
                Endurance = indicatorDomainModel.Endurance
            };

            return CreatedAtAction(nameof(GetById), new { id = indicatorDto.Id }, indicatorDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIndicatorRequestDto updateIndicatorRequestDto)
        {
            var indicatorDomainModel = new Indicator
            {
                Health = updateIndicatorRequestDto.Health,
                MentalEnergy = updateIndicatorRequestDto.MentalEnergy,
                MentalStrength = updateIndicatorRequestDto.MentalStrength,
                Strength = updateIndicatorRequestDto.Strength,
                Dexterity = updateIndicatorRequestDto.Dexterity,
                Agility = updateIndicatorRequestDto.Agility,
                Evasion = updateIndicatorRequestDto.Evasion,
                Endurance = updateIndicatorRequestDto.Endurance
            };

            indicatorDomainModel = await indicatorRepository.UpdateAsync(id, indicatorDomainModel);

            if (indicatorDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to DTO
            var indicatorDto = new IndicatorDto
            {
                Id = indicatorDomainModel.Id,
                Health = indicatorDomainModel.Health,
                MentalEnergy = indicatorDomainModel.MentalEnergy,
                MentalStrength = indicatorDomainModel.MentalStrength,
                Strength = indicatorDomainModel.Strength,
                Dexterity = indicatorDomainModel.Dexterity,
                Agility = indicatorDomainModel.Agility,
                Evasion = indicatorDomainModel.Evasion,
                Endurance = indicatorDomainModel.Endurance
            };

            return Ok(indicatorDto);
    }

        [HttpDelete]
        [Route("{id:Guid}")]
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
