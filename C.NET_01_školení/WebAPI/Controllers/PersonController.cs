using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly People_context _db;
        public PersonController(People_context db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Person> GetPeople()
        {
            return _db.Persons.Include(x=>x.Contracts)
                .Include(x=>x.HomeAddress);
        }

        [HttpGet("ByEmail/{email}")]
        public Person GetbyEmail(string email)
        {
            return _db.Persons.Include(x => x.Contracts)
                .Include(x => x.HomeAddress)
                .Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault();    
        }
        [HttpGet("{id}")]
        public Person GetbyId(int id)
        {
            return _db.Persons.Include(x => x.Contracts)
                .Include(x => x.HomeAddress).FirstOrDefault(p => p.Id==id);
        }
    }
}
