//using System;
using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp
{
    [ApiController]
    [Route("api/[controller]") ] //api/users
public class UsersCOntroller: ControllerBase 
    {

        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public UsersCOntroller(DataContext context,IConfiguration configuration)
       {
        _configuration = configuration;
        _context = context;
       }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
    var users = await _context.Users.ToListAsync();
    return users;
    }  

    [HttpGet("{id:int}")]
    public async Task <ActionResult<AppUser>> GetUser(int id)
    {
    var user = await  _context.Users.FindAsync (id);

    if(user == null) return NotFound();

    return user;

    } 

    }

}
