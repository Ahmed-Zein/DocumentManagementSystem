using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using dms_webapi.Entities;
using dms_webapi.Models;
using dms_webapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace dms_webapi.Controllers;

[Route("api/auth")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices, IMapper mapper, IJwtService jwtService)
    {
        _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
        _mapper = mapper;
        _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserRegistrationResponseDto>> RegisterUser(
        UserRegistrationRequestDto userRegistrationRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userServices.RegisterUser(userRegistrationRequestDto);
        if (user == null)
        {
            return BadRequest();
        }

        var token = _jwtService.GenerateToken(user);
        Console.WriteLine(token);
        var res = _mapper.Map<UserRegistrationResponseDto>(user, opt => opt.Items["token"] = token);

        return Ok(res);
    }

    // TODO: add login 
    [HttpPost("login")]
    public async Task<ActionResult> LoginInUser()
    {
        return Ok();
    }
}