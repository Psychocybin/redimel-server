﻿using redimel_server.Infrastructure;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public interface IUserRepository
    {
        string GetUserEmail();

        Task<User> CreateUserAsync(string heroEmail, GroupWestHeroes groupWestHeroes);

        Task<string?> RemoveBattleGroup(string heroEmail);

        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(Guid id);

        Task<User?> UpdateAsync(Guid id, User user);

        Task<User?> DeleteAsync(Guid id);
    }
}
