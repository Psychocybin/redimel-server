using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using redimel_server.Models.DTO;

namespace redimel_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorsController : ControllerBase
    {
        private readonly RedimelServerDbContext dbContext;

        public IndicatorsController(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var indicatorsDomain = dbContext.Indicators;

            var indicatorsDto = new List<IndicatorsDto>();
            foreach (var indicator in indicatorsDomain)
            {
                indicatorsDto.Add(new IndicatorsDto()
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

            return Ok(indicatorsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var indicatorsDomain = dbContext.Indicators.Find(id);

            //var indicators = dbContext.Indicators.FirstOrDefault(x => x.Id == id);

            if (indicatorsDomain == null)
            {
                return NotFound();
            }

            var indicatorsDto = new IndicatorsDto
            {
                Id = indicatorsDomain.Id,
                Health = indicatorsDomain.Health,
                MentalEnergy = indicatorsDomain.MentalEnergy,
                MentalStrength = indicatorsDomain.MentalStrength,
                Strength = indicatorsDomain.Strength,
                Dexterity = indicatorsDomain.Dexterity,
                Agility = indicatorsDomain.Agility,
                Evasion = indicatorsDomain.Evasion,
                Endurance = indicatorsDomain.Endurance
            };

            return Ok(indicatorsDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddIndicatorsRequestDto addIndicatorsRequestDto)
        {
            var indicatorsDomainModel = new Indicators
            {
                Health = addIndicatorsRequestDto.Health,
                MentalEnergy = addIndicatorsRequestDto.MentalEnergy,
                MentalStrength = addIndicatorsRequestDto.MentalStrength,
                Strength = addIndicatorsRequestDto.Strength,
                Dexterity = addIndicatorsRequestDto.Dexterity,
                Agility = addIndicatorsRequestDto.Agility,
                Evasion = addIndicatorsRequestDto.Evasion,
                Endurance = addIndicatorsRequestDto.Endurance
            };

            dbContext.Indicators.Add(indicatorsDomainModel);
            dbContext.SaveChanges();

            var indicatorsDto = new IndicatorsDto
            {
                Id = indicatorsDomainModel.Id,
                Health = indicatorsDomainModel.Health,
                MentalEnergy = indicatorsDomainModel.MentalEnergy,
                MentalStrength = indicatorsDomainModel.MentalStrength,
                Strength = indicatorsDomainModel.Strength,
                Dexterity = indicatorsDomainModel.Dexterity,
                Agility = indicatorsDomainModel.Agility,
                Evasion = indicatorsDomainModel.Evasion,
                Endurance = indicatorsDomainModel.Endurance
            };

            return CreatedAtAction(nameof(GetById), new { id = indicatorsDto.Id}, indicatorsDto);
        }
    }
}
