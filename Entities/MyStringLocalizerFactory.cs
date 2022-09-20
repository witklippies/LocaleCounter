using Microsoft.Extensions.Localization;

using LocaleCounter.Data;

namespace LocaleCounter.Entities;

public class MyStringLocalizerFactory : IStringLocalizerFactory
{
    private readonly LocalizationDBContext _context;

    public MyStringLocalizerFactory()
    {
        _context = new LocalizationDBContext();
        _context.AddRange (
            new Culture
            {
                Name = "en-ZA",
                Words = new List<Word>() { new Word {Key = "Zero", Value = "Zero"}, { new Word {Key = "One", Value = "One"} } }
            },
            new Culture
            {
                Name = "af-ZA",
                Words = new List<Word>() { new Word {Key = "Zero", Value = "Nul"}, { new Word {Key = "One", Value = "Een"} } }
            }
        );
        _context.SaveChanges();
    }

    public IStringLocalizer Create(Type resourceSource)
    {
        return new MyStringLocalizer(_context);
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return new MyStringLocalizer(_context);
    }
}