﻿namespace redimel_server.Models.Domain
{
    public class Negotiation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AditionalPointsId { get; set; }
        public AditionalPoint AditionalPoints { get; set; }
    }
}
