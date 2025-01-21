using HelpDeskPro.Models;

namespace HelpDeskPro.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<Ticket>> GetTicketsByClientIdAsync(int clientId);
        Task<Ticket?> GetTicketByIdAsync(int id);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task UpdateTicketStatusAsync(int id, string status);
        Task DeleteTicketAsync(int id);
    }
}
