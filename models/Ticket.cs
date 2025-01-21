using System;

namespace HelpDeskPro.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Priority { get; set; } = "Low"; 
        public string Status { get; set; } = "Pending"; 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relacionamento com User (Cliente e Técnico)
        public int ClientId { get; set; }
        public User? Client { get; set; }
        public int? TechnicianId { get; set; }
        public User? Technician { get; set; }
    }
}
