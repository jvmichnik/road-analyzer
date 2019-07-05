using System;
using Newtonsoft.Json;

namespace ZEventBus.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            IdEvent = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            IdEvent = id;
            CreationDate = createDate;
        }

        [JsonProperty]
        public Guid IdEvent { get; private set; }

        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}
