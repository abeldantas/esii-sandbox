using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sandbox.Data;

namespace Sandbox.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class ArtistController : Controller
{
    readonly ApplicationDbContext _context;

    public ArtistController( ApplicationDbContext context )
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetArtists()
    {
        var artists = await _context.Artists.ToListAsync();
        return Ok( artists );
    }
}