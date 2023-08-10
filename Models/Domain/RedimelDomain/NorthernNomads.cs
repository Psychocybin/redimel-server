﻿namespace redimel_server.Models.Domain.RedimelDomain
{
    public class NorthernNomads
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> NorthernNomadsVariables { get; set; }
    }
}