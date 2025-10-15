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

        var authors = await context.Authors.ToListAsync();

        var authorViewModels = authors.Select(author => new AuthorViewModel
        {
            Id = author.Id,
            Name = author.Name,
            Description = author.Description,
            BirthDate = author.BirthDate,
            Photo = author.Photo,
            PhotoMimeType = author.PhotoMimeType
        });

        return authorViewModels;

        //Old-fashioned way
        //var authorList = new List<AuthorViewModel>();
        //foreach (var author in authorViewModels)
        //{
        //    authorList.Add(new AuthorViewModel
        //    {
        //        Id = author.Id,
        //        Name = author.Name,
        //        Description = author.Description,
        //        Photo = author.Photo,
        //        PhotoMimeType = author.PhotoMimeType
        //    });
        //}
    }
}