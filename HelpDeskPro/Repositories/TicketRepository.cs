using HelpDeskPro.Data;
using HelpDeskPro.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskPro.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByClientIdAsync(int clientId)
        {
            return await _context.Tickets
                .Where(t => t.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByTechnicianIdAsync(int technicianId)
        {
            return await _context.Tickets
                .Where(t => t.TechnicianId == technicianId && t.Status != "Closed")
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetOpenTicketsAsync()
        {
            return await _context.Tickets
                .Where(t => t.Status == "Pending" || t.Status == "In Progress")
                .ToListAsync();
        }
    }
}
