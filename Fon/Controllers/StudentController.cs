using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FonData.Helpers;
using FonData.Interface;
using FonData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fon.Controllers
{
    [Route("fon/studenti")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private ILibraryStudent _student;
        private readonly AppSettings _appSettings;


        public StudentController(ILibraryStudent student, IOptions<AppSettings> appSettings)
        {
            _student = student;
            _appSettings = appSettings.Value;
           
        }

        // GET: api/Igrac
        [HttpGet(Name ="VratiStudente1")]
        [AllowAnonymous]
        public async Task<ActionResult<List<StudentRegister>>> VratiStudente()
        {

            try
            {
                var studenti = _student.VratiStudente();
                var noviStudenti = CreateStudent(studenti);
                return Ok(noviStudenti);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        private List<StudentRegister> CreateStudent(IEnumerable<Student> studenti)
        {
            List<StudentRegister> studentiVrati = new List<StudentRegister>();
            studenti.ToList().ForEach((student) =>
            {
                StudentRegister st = new StudentRegister()
                {
                    Administrator = student.Administrator,
                    Biografija = student.Biografija,
                    Email = student.Email,
                    GodinaStudija = student.GodinaStudija,
                    ImageUrl = student.ImageUrl,
                    Ime = student.Ime,
                    InstagramUrl = student.InstagramUrl,
                    Password = Encoding.UTF8.GetString(student.PasswordHash),
                    Prezime = student.Prezime,
                    Status = student.Status,
                    StudentId = student.StudentId,
                    Username = student.Username

                };
                studentiVrati.Add(st);
            });
            return studentiVrati;
        }
        [HttpPost("aut")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody]AuthenticateRequest request)
        {
            var student = _student.PrijaviKorisnika(request.Username, request.Password);
            if (student is null) return NotFound();

            var tokenString = CreateToken(student);
            AuthenticateResponse response = CreateResponse(tokenString, student);
            return Ok(response);
        }
        private string CreateToken(Student student)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, student.StudentId.ToString()),
                    new Claim(ClaimTypes.Role, student.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        private AuthenticateResponse CreateResponse(string token, Student student)
        {
            AuthenticateResponse response = new AuthenticateResponse();
            response.Email = student.Email;
            response.Id = student.StudentId;
            response.Token = token;
            response.Username = student.Username;
            response.Role = student.Role;
            return response;
        }

        // GET: api/Igrac/5
        [HttpGet("{id}")]
        public ActionResult<Student> VratiJednog(int id)
        {
            try
            {
                var student = _student.VratiStudenta(id);
                if (student is null) return NotFound();
                return Ok(student);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/clan")]
        public ActionResult<IEnumerable<StudentskaOrganizacija>> VratiClanId(int id)
        {
            Student st = new Student() { StudentId = id };
            var clan = _student.VratiOrganizacijeClan(st);
            if (clan is null) return NotFound();
            return Ok(clan);
           
        }

        [HttpGet("{id}/subscribe")]
        public ActionResult<IEnumerable<StudentskaOrganizacija>> VratiSubscribeId(int id)
        {
            var clan = _student.VratiSubscribeStudenta(id);
            if (clan is null) return NotFound();
            return Ok(clan);

        }



        // POST: api/Igrac
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Student>> AddStudent([FromBody] StudentRegister student)
        {
            if (_student.AddStudent(student)) return RedirectToRoute("VratiStudente1");
            return NotFound();
        }

        // PUT: api/Igrac/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Student>> Put(int id, [FromBody] StudentRegister student)
        {
            student.StudentId = id;
            if (_student.UpdateStudent(student)) return Ok(_student.VratiStudente());
            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_student.DeleteStudent(id)) return NoContent();
            return NotFound();
        }
    }
}
