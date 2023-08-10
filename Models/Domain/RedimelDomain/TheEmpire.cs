﻿namespace redimel_server.Models.Domain.RedimelDomain
{
    public class TheEmpire
    {
        public Guid Id { get; set; }
        public Guid RedimelId { get; set; }
        public virtual ICollection<WorldInfoVariable> TheEmpireVariables { get; set; }
    }
}