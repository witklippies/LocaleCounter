using System.Globalization;
namespace LocaleCounter.Entities;

public interface INumberToWords
{
    string Convert(int i); 
}
class NumberToWordsLocal  : INumberToWords
{  
    private static string[] units = { "Zero", "One", "Two", "Three",  
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",  
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",  
    "Seventeen", "Eighteen", "Nineteen" };  
    private static string[] tens = { "", "", "Twenty", "Thirty", "Forty",  
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };  
  
    public string Convert(int i)  
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
}  

class CultureWords
{
    private string _culture;
    private string[] _units;
    private string[] _tens;

    public CultureWords(string culture, string[] units, string[] tens)
    {
        _culture = culture;
        _units = units;
        _tens = tens;
    }

    public string getCulture()
    {
        return _culture;
    }

    public string[] getUnits()
    {
        return _units;
    }

    public string[] getTens()
    {
        return _tens;
    }
}

//TODO: This is a terrible piece of code, but it proves the point...
class CultureWordFactory
{
    private List<CultureWords> cultureWordList;

    public CultureWordFactory()
    {
       cultureWordList = new List<CultureWords>(); 

       var cultureWord = new CultureWords("en-ZA", 
            new string[] { "Zero", "One", "Two", "Three",  "Four", "Five", 
                "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",  "Twelve",
                "Thirteen", "Fourteen", "Fifteen", "Sixteen",  "Seventeen",
                "Eighteen", "Nineteen" }, 
            new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty",
                 "Sixty", "Seventy", "Eighty", "Ninety" });

       cultureWordList.Add(cultureWord);

       cultureWord = new CultureWords("af-ZA", 
            new string[] { "Nul", "Een", "Twee", "Drie",  "Vier", "Vyf", 
                "Ses", "Seve", "Agt", "Nege", "Tien", "Elf",  "Twaalf",
                "Dertien", "Veertien", "Vyftien", "Sestien",  "Seventien",
                "Agtien", "Negentien" }, 
            new string[] { "", "", "Twintig", "Dertig", "Veertig", "Fyftig",
                 "Sestig", "Seventig", "Tagtig", "Negentig" });

       cultureWordList.Add(cultureWord);

       cultureWord = new CultureWords("en-US", 
            new string[] { "Zero", "One", "Two", "Three",  "Four", "Five", 
                "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",  "Twelve",
                "Thirteen", "Fourteen", "Fifteen", "Sixteen",  "Seventeen",
                "Eighteen", "Nineteen" }, 
            new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty",
                 "Sixty", "Seventy", "Eighty", "Ninety" });

       cultureWordList.Add(cultureWord);
    }

    public string Convert(int i)
    {
        var value = "Conversion for number not implemented";

        foreach(CultureWords cw in cultureWordList)
        {
            if (cw.getCulture() == CultureInfo.CurrentCulture.Name)
            {
                if (i < 20)  
                {  
                    value = cw.getUnits()[i];  
                }  
                else if (i < 100)  
                {  
                    value =  cw.getTens()[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");  
                }  
            }
        }

        return CultureInfo.CurrentCulture.Name + ": " + value;  
    }
}

class NumberToWordsLocalCulture  : INumberToWords
{  
    public string Convert(int i)  
    {  
        var cwf = new CultureWordFactory();
        return  cwf.Convert(i);  
    }  
} 