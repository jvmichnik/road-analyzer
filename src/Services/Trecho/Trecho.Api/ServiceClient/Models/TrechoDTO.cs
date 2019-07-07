using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trecho.Api.ServiceClient.Models
{
    public class TrechoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public IEnumerable<LogDTO> Logs { get; set; }
    }
}
