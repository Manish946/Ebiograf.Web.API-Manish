
using AutoMapper;
using EBiograf.Web.Api.Helper;
using EBiograf.Web.Api.Models;
using EBiograf.Web.Api.Repository.UserRepo;
using EBiograf.Web.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ebiograf.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public IUserService context { get; set; }
        public UserController(IUserService _context, IMapper mapper, IOptions<AppSettings> appSetings) // Depoedency Injection
        {
            context = _context;
            _mapper = mapper;
            _appSettings = appSetings.Value;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = context.Authenticate(model.UserName, model.Password);
            
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            // return basic user info and authentication token
            var userModel = _mapper.Map<UserModel>(user);
            userModel.Token = tokenString;
            //return Ok(new
            //{
            //    Id = user.UserID,
            //    username = user.UserName,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    EmailAddress = user.EmailAddress,
            //    Phone = user.Phone,
            //    DateCreated = user.DateCreated,
            //    token = tokenString
            //});
            return Ok(userModel);
           // return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModelUser model)
        {
            var user = _mapper.Map<User>(model);
            try
            {
                // Create user
                context.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        //AllowAnonymous lets users who have not been authenticated access the action or controller.In short, it knows based on the token it receives from the client.
        //Http Get Request to Get All Users Frmo the Database.
        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await context.GetAllUsers();
            var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(model);

        }

        [HttpGet("{id}")]
        [Authorize]

        public IActionResult GetById(int id)
        {
            var user = context.GetById(id);
            var model = _mapper.Map<UserModel>(user);
            return Ok(model);
        }
        
        [HttpDelete("id")]
        [Authorize]

        public IActionResult Delete(int id)
        {
            context.delete(id);
            return Ok();
        }


        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody]UpdateModel model)
        {
            // Map modelto entity and set id.
            var user = _mapper.Map<User>(model);
            user.UserID = id;

            try
            {
                // Update user
                context.Update(user, model.Password);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
        }
    }
}
