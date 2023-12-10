namespace LingvoTry.Models;

public class Tag
{
    public string TagText { get; set; } = null!;

    public virtual ICollection<Translation> Translations { get; set; } = new List<Translation>();
}