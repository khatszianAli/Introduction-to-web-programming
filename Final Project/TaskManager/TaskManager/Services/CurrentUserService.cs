using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Services;

public class CurrentUserService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly IDbContextFactory<AppDbContext> _dbFactory;

    public CurrentUserService(AuthenticationStateProvider authStateProvider, IDbContextFactory<AppDbContext> dbFactory)
    {
        _authStateProvider = authStateProvider;
        _dbFactory = dbFactory;
    }

    public async Task<User?> GetCurrentUserAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var username = authState.User.FindFirst(ClaimTypes.Name)?.Value;

        if (string.IsNullOrWhiteSpace(username))
        {
            return null;
        }

        await using var db = await _dbFactory.CreateDbContextAsync();
        return await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<int?> GetCurrentUserIdAsync()
    {
        return (await GetCurrentUserAsync())?.Id;
    }
}
