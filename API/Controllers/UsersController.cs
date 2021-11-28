using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Application.Users;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtTokenService _jwtTokenService;

        public UsersController(UserManager<User> userManager , SignInManager<User> signInManager , IMapper mapper , JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            User user = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null)
                return Unauthorized("Incorrect email");

            var result = await _signInManager.CheckPasswordSignInAsync(user , userLoginDto.Password , false);

            if (!result.Succeeded)
                return Unauthorized("Incorrect password");

            UserDto userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _jwtTokenService.CreateJwtToken(user);
            return userDto;

        }
        
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto userRegisterDto)
        {
            if(await _userManager.Users.AnyAsync(u => u.Email == userRegisterDto.Email))
            {
                ModelState.AddModelError("email" , "Email is already taken");
                return ValidationProblem();
            }

            if(await _userManager.Users.AnyAsync(u => u.UserName == userRegisterDto.UserName))
            {
                ModelState.AddModelError("username", "Username is already taken");
                return ValidationProblem();
            }

            User user = _mapper.Map<User>(userRegisterDto);
            IdentityResult result = await _userManager.CreateAsync(user , userRegisterDto.Password);

            if (!result.Succeeded)
                return BadRequest("Registration problem, please try again later.");

            //dodać wysyłanie e-maila

            return Ok("Account created successfully");

        }
    }
}