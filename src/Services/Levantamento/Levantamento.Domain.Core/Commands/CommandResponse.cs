﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Core.Commands
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse { Success = true };
        public static CommandResponse Fail = new CommandResponse { Success = false };

        public CommandResponse(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }

        public static implicit operator bool(CommandResponse commandResponse)
        {
            return commandResponse.Success;
        }
    }
}
