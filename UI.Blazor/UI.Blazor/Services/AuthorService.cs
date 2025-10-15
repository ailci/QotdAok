using Application.Contracts.Services;
using Application.ViewModels.Author;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Services;

public class AuthorService(ILogger<AuthorService> logger, IDbContextFactory<QotdContext> contextFactory) : IAuthorService
{
    public async Task<IEnumerable<AuthorViewModel>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} aufgerufen...");

        await using var context = await contextFactory.CreateDbContextAsync();
    }
}