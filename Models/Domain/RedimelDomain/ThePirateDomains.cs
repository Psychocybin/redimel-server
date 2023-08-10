﻿namespace redimel_server.Models.Domain.RedimelDomain
{
    public class ThePirateDomains
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> ThePirateDomainsVariables { get; set; }
    }
}