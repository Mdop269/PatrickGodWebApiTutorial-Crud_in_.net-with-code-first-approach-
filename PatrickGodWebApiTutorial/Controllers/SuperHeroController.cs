using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatrickGodWebApiTutorial.Data;
using PatrickGodWebApiTutorial.Entities;

namespace PatrickGodWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllHeroes()
        //{
        //    var heroes = new List<SuperHero>
        //    {
        //        new SuperHero
        //        {
        //            Id = 1,
        //            Name = "Test",
        //            FirstName = "Test",
        //            LastName = "Test",
        //            Place = "test"
        //        }
        //    };
        //    return Ok(heroes);
            

        //}

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null) {
                return BadRequest("Not found");
            };
            return Ok(hero);

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> addHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdatedHero(SuperHero UpdtedHero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(UpdtedHero.Id);
            if (dbHero == null)
            {
                return BadRequest("Not found");
            };

            dbHero.Name = UpdtedHero.Name;
            dbHero.FirstName = UpdtedHero.FirstName;
            dbHero.LastName = UpdtedHero.LastName;
            dbHero.Place = UpdtedHero.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());

        }

        [HttpDelete]
        public async Task<ActionResult<SuperHero>> DeleteHero(int Id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(Id);
            if (dbHero == null)
            {
                return BadRequest("Not found");
            };
            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());

        }
    }
}
