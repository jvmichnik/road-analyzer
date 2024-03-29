﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos.Create.DTO
{
    public class CreateLeventamentoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
