using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    
    [Route( "api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager ;

        private readonly ITokenService _tokenService ;

        private readonly SignInManager<AppUser> _signinManager ;

        // public AccountController( UserManager<AppUser> UserManager, ITokenService tokenService ){
        public AccountController( UserManager<AppUser> UserManager, ITokenService tokenService, SignInManager<AppUser> signinManager ){
            _userManager = UserManager ;
            _tokenService = tokenService ;
            _signinManager = signinManager ;

        }
    
        
        [HttpPost("login")]
        public async Task<IActionResult> Login( LoginDto loginDto ) {
            if ( ModelState.IsValid)
                return BadRequest( ModelState );

            var user = await _userManager.Users.FirstOrDefaultAsync( x => x.UserName == loginDto.Username.ToLower() ) ; 
            if ( user == null ) {
                return Unauthorized( "Invalid username!") ;
            }

            var result = await _signinManager.CheckPasswordSignInAsync( user, loginDto.Password, false ) ;

            if ( !result.Succeeded ) {
                return Unauthorized( "Username not found and/or password not found" ) ;
            }

            NewUserDto successUser = new NewUserDto(
                user.UserName,
                user.Email,
                _tokenService.CreateToken( user )
            ) ;
            return Ok ( successUser) ; 
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register( [FromBody] RegisterDto registerDto ) {
            try {
                if (!ModelState.IsValid) {
                    return BadRequest( ModelState ) ;
                }
                var appUser = new AppUser {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                } ;
    
                var createdUser = await _userManager.CreateAsync( appUser, registerDto.Password ) ;
                if ( createdUser.Succeeded ){
                    var roleResult = await _userManager.AddToRoleAsync( appUser, "User") ;
                    if ( roleResult.Succeeded ) {

                                                    
                        NewUserDto newUser = new NewUserDto
                            (
                                appUser.UserName,
                                appUser.Email,
                                _tokenService.CreateToken( appUser )
                            ) ;

                        return Ok( newUser ) ;
                    }
                    else {
                        return StatusCode( 500, roleResult.Errors ) ;
                    }
                }
                else {
                
                    return StatusCode( 500, createdUser.Errors ); 
                }
    
            }
            catch ( Exception e ) {
                return StatusCode( 500,e ) ;
            }
    
        }
    }
    
}