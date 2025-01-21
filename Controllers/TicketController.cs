using HelpDeskPro.Models;
using HelpDeskPro.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // 1. Listar todos os tickets
        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        // 2. Buscar tickets por cliente
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetTicketsByClient(int clientId)
        {
            var tickets = await _ticketService.GetTicketsByClientIdAsync(clientId);
            return Ok(tickets);
        }

        // 3. Criar um novo ticket
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTicket = await _ticketService.CreateTicketAsync(ticket);
            return CreatedAtAction(nameof(GetAllTickets), new { id = createdTicket.Id }, createdTicket);
        }

        // 4. Atualizar o status de um ticket
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketStatus(int id, [FromBody] string status)
        {
            try
            {
                await _ticketService.UpdateTicketStatusAsync(id, status);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // 5. Deletar um ticket
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                await _ticketService.DeleteTicketAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
