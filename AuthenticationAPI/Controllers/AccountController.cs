using AuthenticationAPI.Services;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountController: ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;

    public AccountController(JwtTokenHandler jwtTokenHandler)
    {
        _jwtTokenHandler = jwtTokenHandler;
    }

    // private readonly AuthenticationHandler _authenticationHandler;
    //
    // public AccountController(JwtTokenHandler jwtTokenHandler, AuthenticationHandler authenticationHandler)
    // {
    //     _jwtTokenHandler = jwtTokenHandler;
    //     _authenticationHandler = authenticationHandler;
    // }


    // [HttpPost]
    // [Route("login")]
    // public async  Task<IActionResult> Login(AuthenticationRequest req)
    // {
    //     var user = await  _authenticationHandler.IsValidUser(req);
    //     if (user == null) return Unauthorized();
    //     var authResponse = _jwtTokenHandler.GenerateToken(user);
    //
    //     return Ok(authResponse);
    // }
    
    [HttpPost]
    [Route("loginFromMockUser")]
    public   ActionResult<AuthenticationResponse> LoginFromMockUser(AuthenticationRequest req)
    {
        var authResponse = _jwtTokenHandler.GenerateTokenFromMockUser(req);
        if (authResponse == null) return Unauthorized();

        
        return Ok(authResponse);
    }
    
}