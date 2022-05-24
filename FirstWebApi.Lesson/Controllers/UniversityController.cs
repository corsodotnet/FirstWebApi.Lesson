using FirstWebApi.Lesson.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebApi.Lesson.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
         private  UniversityContext _context;
        public UniversityController(UniversityContext context)
        {
            _context = context;
        }
        // GET: api/<UniversityController>
        [HttpGet]
        public IEnumerable<Corso> Get()
        {
            Corso corso;
            using(_context)
            {
                try
                {
                  return _context.Corso.ToList();
                    
                }
                catch (System.Exception ex )
                {
                    throw;
                }

        }

        // GET api/<UniversityController>/5
        [HttpGet("{id}")]
        public Corso Get(string Title)
        {
            Corso corso;
            corso = _context.Corso
                     .Where(c => c.Name == Title).First();
            var data = _context.Corso
                .Include(s => s.Students)
                .First(x => x.Id == corso.Id);


            return corso;
        }

        // POST api/<UniversityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
           

        }

        // PUT api/<UniversityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _context.Update();
        }

        // DELETE api/<UniversityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Remove();
        }
    }
}
