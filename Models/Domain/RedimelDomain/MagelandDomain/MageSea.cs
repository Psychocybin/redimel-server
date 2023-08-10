﻿namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageSea
    {
        public Guid Id { get; set; }
        public Guid MagelandId { get; set; }
        public virtual ICollection<WorldInfoVariable> MageSeaVariables { get; set; }
    }
}