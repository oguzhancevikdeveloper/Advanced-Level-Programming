


MyObservable myObservable = new MyObservable();
using var sub1 = myObservable.Subscribe(new MyObserver("A"));
using var sub2 = myObservable.Subscribe(new MyObserver("B"));
using var sub3 = myObservable.Subscribe(new MyObserver("C"));

myObservable.NotifyObservers(15); 
myObservable.NotifyObservers(20); 
myObservable.NotifyObservers(25); 


class MyObservable : IObservable<int>
{

    List<IObserver<int>> _observers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {

        if (!_observers.Contains(observer)) _observers.Add(observer);

        return new UnSubscription(() =>
        {
            _observers.Remove(observer);
            observer.OnCompleted();
        });   
    }
    public void NotifyObservers(int value) => _observers.ForEach(x => x.OnNext(value));
}

class UnSubscription(Action unSubscription) : IDisposable
{
    public void Dispose()
    {
        unSubscription?.Invoke();
        unSubscription = null;
    }
}

class MyObserver(string observerName) : IObserver<int>
{
    public void OnCompleted() => Console.WriteLine($"{observerName}, observer takibi tamamlandı.");
    public void OnError(Exception error) => Console.WriteLine("Hata!!");
    public void OnNext(int value) => Console.WriteLine($"Observer: {value}.");
}