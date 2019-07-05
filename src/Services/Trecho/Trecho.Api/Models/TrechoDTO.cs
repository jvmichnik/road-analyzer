﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trecho.Api.Models
{
    public class TrechoDTO
    {
        public TrechoDTO(Guid id, string name, string description, DateTime start)
        {
            Id = id;
            Name = name;
            Description = description;
            Start = start;

        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }
    }
}