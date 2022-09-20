namespace LocaleCounter.Entities;

public interface IMyCounter
{
    int count();

    int value();
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
    public int value()
    {
        return _counter;
    }
}
