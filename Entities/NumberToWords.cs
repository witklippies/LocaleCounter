using System.Globalization;
using Microsoft.Extensions.Localization;

using LocaleCounter.Data;

namespace LocaleCounter.Entities;

public interface INumberToWords
{
    string Convert(int i); 
}
class NumberToWords : INumberToWords
{  
    private static string[] units = { "Zero", "One", "Two", "Three",  
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",  
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",  
    "Seventeen", "Eighteen", "Nineteen" };  
    private static string[] tens = { "", "", "Twenty", "Thirty", "Forty",  
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };  

    protected string ConvertInternal(int i)
    {
        if (i < 20)  
        {  
            return units[i];  
        }  
        if (i < 100)  
        {  
            return tens[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");  
        }  
        return "Not implemented";
    }
  
    public virtual string Convert(int i)  
    {  
        return ConvertInternal(i);
    }  
}  

// ***** Extend NumerToWords to include string localisation
class NumberToWordsCulture  : NumberToWords
{  
    private readonly IStringLocalizer _sl;

    public NumberToWordsCulture(IStringLocalizer sl)
    {
        _sl = sl;
    }
    public override string Convert(int i)
    {  
        return _sl[ConvertInternal(i)];
    }  
} 