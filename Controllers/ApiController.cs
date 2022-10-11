using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueryTypes.Models;
using QueryTypes.Data;

namespace QueryTypes.Controllers
{
    [ApiController]
    [Route("v1/controller")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("people")]
        public async Task<ActionResult<List<People>>> GetPeople([FromServices] DataContext context){
            return await context.People
            .Include(i => i.BestGame)
            .ToListAsync();
        }

        [HttpPost]
        [Route("people")]
        public async Task<ActionResult<People>> SavePeople([FromServices] DataContext context, [FromBody] People people){
            if(ModelState.IsValid){

                context.People.Add(people);
                await context.SaveChangesAsync();

                return people;
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("people")]
        public async Task<ActionResult<People>> PutPeople([FromServices] DataContext context, [FromBody] People people){

            if(ModelState.IsValid){

                context.People.Add(people);
                await context.SaveChangesAsync();

                return people;
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("people/{id}")]
        public async Task<ActionResult<People>> DeletePeople([FromServices] DataContext context, [FromRoute] int id){
            
            var people = await context.People.FirstOrDefaultAsync(p => p.Id == id);

            if(people != null){
                context.People.Remove(people);
                await context.SaveChangesAsync();
            }

            return NotFound();
        }

        [HttpGet]
        [Route("people/{id}")]
        public async Task<ActionResult<People>> GetPeople([FromServices] DataContext context, [FromRoute] int id){
            return await context.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpPost]
        [Route("bestgame")]
        public async Task<ActionResult<BestGame>> SaveBestGame([FromServices] DataContext context, [FromBody] BestGame bestGame){
            if(ModelState.IsValid){

                context.BestGames.Add(bestGame);
                await context.SaveChangesAsync();

                return bestGame;
            }

            return BadRequest(ModelState);
        }
    }
}