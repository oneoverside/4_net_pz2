namespace LingvoTry.Models;

public class Translation
{
    public int? TranslationId { get; set; }
    public string Sentence { get; set; } = null!;
    public string SentenceTranslate { get; set; }  = null!;
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public double Rating { get; set; } = 0;
    public override string ToString() => $"{Sentence}: {SentenceTranslate}; ({string.Join(", ", Tags.Select(x => x.TagText))})";
}

