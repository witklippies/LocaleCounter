namespace LocaleCounter.Entities;

public class Culture
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Word> Words { get; set; }
}