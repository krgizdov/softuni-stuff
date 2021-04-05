using ApiDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public CandidatesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            return this.db.Candidates.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> Get(int id)
        {
            var candidate = await this.db.Candidates.FirstOrDefaultAsync(c => c.Id == id);

            if (candidate == null)
            {
                return this.NotFound();
            }

            return candidate;
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> Post(Candidate candidate)
        {
            await this.db.Candidates.AddAsync(candidate);

            await this.db.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { id = candidate.Id }, candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CandidateUpdateModel candidate)
        {
            var dbCandidate = await this.db.Candidates.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCandidate == null)
            {
                return this.NotFound();
            }

            dbCandidate.Names = candidate.Names;
            dbCandidate.YearsOfExperience = candidate.YearsOfExperience;

            await this.db.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidate>> Delete(int id)
        {
            var dbCandidate = await this.db.Candidates.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCandidate == null)
            {
                return this.NotFound();
            }

            this.db.Candidates.Remove(dbCandidate);
            await this.db.SaveChangesAsync();

            return dbCandidate;
        }
    }
}
