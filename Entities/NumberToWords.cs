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

        return "NaN";
    }  
} 
