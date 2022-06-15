using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("GetAll")]
        
        public List<Person> GetPeople()
        {
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\marie\source\repos\NewRepo\C.NET_01_školení\personal_dataset\dataset.xml");
            return dataset;
        }
        [HttpGet("ByEmail/{email}")]
        public Person GetbyEmail(string email)
        { 
            var dataset = Data.Serialization.LoadFromXML(@"C:\Users\marie\source\repos\NewRepo\C.NET_01_školení\personal_dataset\dataset.xml");
            return dataset.Where(p => p.Email.ToLower() == email.ToLower()).FirstOrDefault();    
        }
    }
}
