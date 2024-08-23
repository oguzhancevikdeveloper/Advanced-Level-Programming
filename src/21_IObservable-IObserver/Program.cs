

/*
   => IObservable<T>: Veri kaynağını temsil eder ve gözlemcileri bu veriler hakkında bilgilendirir.
   => IObserver<T>: Veri kaynağından gelen verileri alan ve işleyen gözlemciyi temsil eder.
 */

var observable = new SimpleObservable();
var observer = new SimpleObserver();

using (observable.Subscribe(observer))
{
    observable.Notify(1);
    observable.Notify(2);
}


public class SimpleObservable : IObservable<int>
{
    private List<IObserver<int>> observers = new List<IObserver<int>>();
    public IDisposable Subscribe(IObserver<int> observer)
    {
        observers.Add(observer);
        return new UnSubscriber(observers, observer);
    }


    public void Notify(int value)
    {
        foreach (var observer in observers) { observer.OnNext(value); }
    }

    private class UnSubscriber(List<IObserver<int>> _observers, IObserver<int> _observer) : IDisposable
    {
        public void Dispose()
        {
            if (_observers.Contains(_observer)) _observers.Remove(_observer);
        }
    }
}


public class SimpleObserver : IObserver<int>
{
    public void OnCompleted() { Console.WriteLine("Sequence completed."); }

    public void OnError(Exception error) { Console.WriteLine("Error: " + error.Message); }

    public void OnNext(int value) { Console.WriteLine("Received value: ", value); }
}
