﻿using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IAuxiliaryRepository
    {
        Task<BattlePoint?> ShowBattlePointsAsync(Guid id);
    }
}
