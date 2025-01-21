using HelpDeskPro.Models;
using HelpDeskPro.Repositories;

namespace HelpDeskPro.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByClientIdAsync(int clientId)
        {
            return await _ticketRepository.GetTicketsByClientIdAsync(clientId);
        }

        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            await _ticketRepository.AddAsync(ticket);
            return ticket;
        }

        public async Task UpdateTicketStatusAsync(int id, string status)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null) throw new Exception("Ticket not found");

            ticket.Status = status;
            await _ticketRepository.UpdateAsync(ticket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _ticketRepository.DeleteAsync(id);
        }
    }
}
