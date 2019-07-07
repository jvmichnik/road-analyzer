using System;

namespace Levantamento.Api.Application.Commands.Levantamentos.Conclude.DTO
{
    public class ConcludeLeventamentoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
