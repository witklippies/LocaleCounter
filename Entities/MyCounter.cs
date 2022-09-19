namespace LocaleCounter.Entities;

public interface IMyCounter
{
    int count();
    string value();
}

public class MyCounter : IMyCounter
{
    private int _counter;
    public MyCounter()
    {
       _counter = 0; 
    }
    public int count()
    { 
        return ++_counter;
    }

    public string value()
    {
        return NumberToWords.Convert(_counter);
    }
}
