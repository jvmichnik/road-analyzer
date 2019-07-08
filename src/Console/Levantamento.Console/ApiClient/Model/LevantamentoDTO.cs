using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Consoles.ApiClient.Model
{
    public class LevantamentoDTO
    {
        public LevantamentoDTO(string name, string description)
        {
            Name = name;
            Description = description;
            Start = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
    }
}
