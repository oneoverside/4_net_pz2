using LingvoTry.Models;
using Microsoft.EntityFrameworkCore;

namespace LingvoTry.DB;

public class EfContext : DbContext
{
    private readonly string _connectionString;

    private DbSet<Translation> Translations { get; set; } = null!;
    private DbSet<Tag> Tags { get; set; } = null!;

    public EfContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Assuming you are using SQL Server; change the provider if using a different database
        optionsBuilder.UseSqlite(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Translation>()
            .ToTable("Translation")
            .HasKey(t => t.TranslationId);
        modelBuilder.Entity<Tag>().ToTable("Tag").HasKey(t => t.TagText);

        modelBuilder.Entity<Translation>()
            .HasMany(t => t.Tags)
            .WithMany(t => t.Translations)
            .UsingEntity<Dictionary<string, object>>(
                "TranslationTagId",
                j => j.HasOne<Tag>().WithMany().HasForeignKey("TagText"),
                j => j.HasOne<Translation>().WithMany().HasForeignKey("TranslationId"),
                j =>
                {
                    j.ToTable("TranslationTag");
                    j.HasKey("TranslationId", "TagText");
                }
            );
    }

    public async Task AddToDb(List<Translation> translations)
    {
        this.AddOrUpdateTags(translations);
        await this.AddOrUpdateTranslations(translations);
        // await this.Translations.AddRangeAsync(translations);
        await this.SaveChangesAsync();
    }

    private async Task AddOrUpdateTranslations(List<Translation> translations)
    {
        var translationsIds = translations.Select(x => x.TranslationId).ToHashSet();
        var translationsInDb = await this.Translations.Where(x => translationsIds.Contains(x.TranslationId)).ToListAsync();
        foreach (var translation in translations)
        {
            var translationInDb = translationsInDb!.FirstOrDefault(x => x.TranslationId == translation.TranslationId);
            if (translationInDb is null)
            {
                await this.Translations.AddAsync(translation);
            }
            else
            {
                translationInDb!.SentenceTranslate = translation.SentenceTranslate;
                translationInDb!.Rating = translation.Rating;
                translationInDb!.Sentence = translation.Sentence;
            }
        }
    }

    private void AddOrUpdateTags(List<Translation> translations)
    {
        var uniqueTags = translations
            .SelectMany(t => t.Tags)
            .DistinctBy(x => x.TagText)
            .ToHashSet();
        
        var uniqueTagTexts = uniqueTags.Select(x => x.TagText).ToHashSet();

        var tagsInDb = this.Tags.Where(x => uniqueTagTexts.Contains(x.TagText)).ToHashSet();

        foreach (var tag in uniqueTags.ToHashSet())
        {
            var tagInDb = tagsInDb.FirstOrDefault(x => x.TagText == tag.TagText);
            if (tagInDb is not null)
            {
                uniqueTags.Remove(tag);
                uniqueTags.Add(tagInDb);
            }
        }

        foreach (var translation in translations)
        {
            foreach (var tag in translation.Tags.ToList())
            {
                var uniqTag = uniqueTags.FirstOrDefault(x => x.TagText == tag.TagText);
                if (uniqTag is not null)
                {
                    translation.Tags.Remove(tag);
                    translation.Tags.Add(uniqTag);
                }
            }
        }
    }
    
    public async Task<List<Translation>> GetFromDb(int count, List<string> tags)
    {
        return await Translations
            // .OrderBy(t => EF.Functions.Random()) 
            .OrderBy(t => t.Rating) 
            .Take(count)
            .Include(x => x.Tags)
            .Where(dbEntity => tags.All(tag => dbEntity.Tags.Any(dbEntityTag => dbEntityTag.TagText == tag)))
            .ToListAsync();
    }
    
    public async Task<List<Translation>> GetFromDb(IEnumerable<int> ids)
    {
        return await Translations
            .Where(x => ids.Contains(x.TranslationId!.Value))
            .ToListAsync();
    }
    
    public async Task<List<Translation>> GetAllTranslationsAsFile(IEnumerable<int> ids)
    {
        return await Translations
            .Where(x => ids.Contains(x.TranslationId!.Value))
            .ToListAsync();
    }
}