﻿namespace redimel_server.Models.Domain.RedimelDomain.MagelandDomain
{
    public class MageTownTheCentralSquare
    {
        public Guid Id { get; set; }
        public Guid MageTownId { get; set; }
        public virtual ICollection<WorldInfoVariable> MageTownTheCentralSquareVariables { get; set; }
    }
}