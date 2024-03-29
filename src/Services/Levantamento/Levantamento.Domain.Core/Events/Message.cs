﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Core.Events
{
    public class Message : IRequest
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
