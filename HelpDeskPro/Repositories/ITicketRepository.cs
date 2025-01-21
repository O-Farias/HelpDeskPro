using HelpDeskPro.Models;

namespace HelpDeskPro.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsByClientIdAsync(int clientId);
        Task<IEnumerable<Ticket>> GetTicketsByTechnicianIdAsync(int technicianId);
        Task<IEnumerable<Ticket>> GetOpenTicketsAsync();
    }
}
