﻿using redimel_server.Utils;

namespace redimel_server.Models.Domain
{
    public class AditionalPoint
    {

        public AditionalPoint()
        {
            this.BattleGroups = new List<BattleGroup>();
            this.Negotiations = new List<Negotiation>();
            this.TeamGame = RedimelConstants.TEAMGAME;
            this.ImportantInformation = RedimelConstants.IMPORTANTINFORMATION;
            this.SlainMonsters = RedimelConstants.SLAINMONSTERS;
            this.Morals = RedimelConstants.MORALS;
            this.Cover = RedimelConstants.COVER;
            this.TemporaryPoints = RedimelConstants.TEMPORARYPOINTS;
        }
        public Guid Id { get; set; }
        public int TeamGame { get; set; }
        public int ImportantInformation { get; set; }
        public int SlainMonsters { get; set; }
        public int Morals { get; set; }
        public int Cover { get; set; }
        public int TemporaryPoints { get; set; }
        public Guid GroupWestId { get; set; }
        public virtual ICollection<BattleGroup> BattleGroups { get; set; }
        public virtual ICollection<Negotiation> Negotiations { get; set; }
    }
}
