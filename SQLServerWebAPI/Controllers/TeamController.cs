using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLServerWebAPI.Models;


namespace SQLServerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context,
                              ILogger<TeamController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("About page visited at {DT}",
                DateTime.UtcNow.ToLongTimeString());
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatePlayerDTO>>> GetTeam()
        {
            return await _context.Teams.ToListAsync();
        }

        // POST: api/Team
        [HttpPost]
        public async Task<ActionResult<CreatePlayerDTO>> PostTeam(CreatePlayerDTO team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }
    }
}
