using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Keyloop.SalesLeads.Api.Data;
using Keyloop.SalesLeads.Api.Models;
using Keyloop.SalesLeads.Api.Contracts;

namespace Keyloop.SalesLeads.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<LeadsController> _logger;
    private readonly IMapper _mapper;

    public LeadsController(AppDbContext context, ILogger<LeadsController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeadResponse>>> GetLeads()
    {
        _logger.LogInformation("Fetching all leads");
        var leads = await _context.Leads
            .Include(l => l.Activities)
            .OrderByDescending(l => l.CreatedDate)
            .ToListAsync();

        return Ok(_mapper.Map<List<LeadResponse>>(leads));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lead>> GetLead(int id)
    {
        var lead = await _context.Leads
            .Include(l => l.Activities)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (lead == null)
            return NotFound();

        lead.Activities = lead.Activities
            .OrderByDescending(a => a.Timestamp)
            .ToList();

        return Ok(lead);
    }

    [HttpPost]
    public async Task<ActionResult<Lead>> AddLead([FromBody] CreateLeadRequest request)
    {
        var lead = _mapper.Map<Lead>(request);

        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Added lead {LeadId} for {Email}", lead.Id, lead.Email);

        return CreatedAtAction(nameof(GetLead), new { id = lead.Id }, lead);
    }

    [HttpPost("{id}/activities")]
    public async Task<ActionResult<LeadActivity>> AddActivity(int id, [FromBody] CreateActivityRequest request)
    {
        var lead = await _context.Leads.FindAsync(id);
        if (lead == null)
            return NotFound();

        var activity = _mapper.Map<LeadActivity>(request);
        activity.LeadId = id;

        _context.LeadActivities.Add(activity);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Added activity for lead {LeadId}", id);

        return Ok(activity);
    }
}
