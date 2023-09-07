using AutoMapper;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetAll()
        {
            var userDomain = await userRepository.GetAllAsync();

            var userDto = mapper.Map<List<UserDto>>(userDomain);

            return Ok(userDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomain = await userRepository.GetByIdAsync(id);

            if (userDomain == null)
            {
                return NotFound();
            }

            var userDto = mapper.Map<UserDto>(userDomain);

            return Ok(userDto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var userDomain = mapper.Map<User>(updateUserRequestDto);

            userDomain = await userRepository.UpdateAsync(id, userDomain);

            if (userDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(userDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var userDomain = await userRepository.DeleteAsync(id);

            if (userDomain == null)
            {
                return NotFound();
            }

            //return deleted Indicator back - optional
            return Ok();
        }
    }
}
