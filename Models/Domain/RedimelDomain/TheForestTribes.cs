﻿namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheForestTribes
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheForestTribesVariables { get; set; }
    }
}
