using System.Globalization;
using Microsoft.Extensions.Localization;

using LocaleCounter.Data;

namespace LocaleCounter.Entities;

public class MyStringLocalizer : IStringLocalizer
{
    private readonly LocalizationDBContext _context;

    public MyStringLocalizer(LocalizationDBContext context)
    {
        _context = context;
    }

    public IStringLocalizer WithCulture(CultureInfo culture)
    {
        CultureInfo.DefaultThreadCurrentCulture = culture;
        return new MyStringLocalizer(_context);
    }

    public LocalizedString this[string name]
    {
        get
        {
            var value = GetString(name);
            return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var format = GetString(name);
            var value = string.Format(format ?? name, arguments);
            return new LocalizedString(name, value, resourceNotFound: format == null);
        }
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    {
        return _context.Words
                .Where(w => w.Culture.Name == CultureInfo.CurrentCulture.Name)
                .Select(w => new LocalizedString(w.Key, w.Value, true));
    }

    private string GetString(string name)
    {
        return _context.Words
                .Where(w => w.Culture.Name == CultureInfo.CurrentCulture.Name)
                .FirstOrDefault(w => w.Key == name)?.Value;
    }
}