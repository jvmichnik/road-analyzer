﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos.Conclude.DTO
{
    public class ConcludeLevantamentoDTO
    {
        public Guid Id { get; set; }
        public DateTime ConcludedAt { get; set; }
    }
}
