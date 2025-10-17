using Application.Contracts.Services;
using Application.Utilities;
using Application.ViewModels.Author;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Services;

public class AuthorService(ILogger<AuthorService> logger, IDbContextFactory<QotdContext> contextFactory) : IAuthorService
{
    public async Task<AuthorViewModel> AddAuthorAsync(AuthorForCreateViewModel authorForCreateViewModel)
    {
        logger.LogInformation($"{nameof(AddAuthorAsync)} aufgerufen mit AuthorForCreate: {authorForCreateViewModel.LogAsJson()}...");
        await using var context = await contextFactory.CreateDbContextAsync();

        var author = new Author
        {
            Name = authorForCreateViewModel.Name,
            Description = authorForCreateViewModel.Description,
            BirthDate = authorForCreateViewModel.BirthDate
        };

        //Bild vorhanden
        if (authorForCreateViewModel.Photo is not null)
        {
            (author.Photo, author.PhotoMimeType) = await authorForCreateViewModel.Photo.GetFile();
        }

        logger.LogInformation($"Author: {author.LogAsJson()}");

        return await Task.FromResult(new AuthorViewModel() { Description = "", Name = "" });
    }

    public async Task<bool> DeleteAuthorAsync(Guid authorId)
    {
        logger.LogInformation($"{nameof(DeleteAuthorAsync)} aufgerufen mit AuthorId: {authorId}...");
        await using var context = await contextFactory.CreateDbContextAsync();

        var author = await context.Authors.FindAsync(authorId);

        if (author is null) return false;

        context.Authors.Remove(author);
        return await context.SaveChangesAsync() > 0;
    }

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