using System.Globalization;
using Microsoft.Extensions.Localization;

namespace LocaleCounter.Entities;

public class MyStringLocalizer : IStringLocalizer
{
    public MyStringLocalizer()
    {
    }

    public IStringLocalizer WithCulture(CultureInfo culture)
    {
        CultureInfo.DefaultThreadCurrentCulture = culture;
        return new MyStringLocalizer();
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
        return new List<LocalizedString>();
    }

    private string GetString(string name)
    {
        return CultureInfo.CurrentCulture.Name;
    }
}