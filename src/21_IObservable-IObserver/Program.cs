

/*
   => IObservable<T>: Veri kaynağını temsil eder ve gözlemcileri bu veriler hakkında bilgilendirir.
   => IObserver<T>: Veri kaynağından gelen verileri alan ve işleyen gözlemciyi temsil eder.
 */

using System.Reactive.Subjects;

internal class Program
{
    private static void Main(string[] args)
    {


        MyObservable myObservable = new();

        using var sub_1 = myObservable.Subscribe(new MyObserver(observerName: "observer_1"));
        using var sub_2 = myObservable.Subscribe(new MyObserver(observerName: "observer_2"));
        var sub_3 = myObservable.Subscribe(new MyObserver(observerName: "observer_3"));
        using var sub_4 = myObservable.Subscribe(new MyObserver(observerName: "observer_4")); // sadece dispaose edilince tammalanır.

        myObservable.Notify(1);
        myObservable.Notify(3);
        myObservable.Notify(5);

        #region Example

        NewsFeed newsFeed = new NewsFeed();
        using var newsSub_1 = newsFeed.Subscribe(new User(UserName: "X"));
        using var newsSub_2 = newsFeed.Subscribe(new User(UserName: "Y"));
        using var newsSub_3 = newsFeed.Subscribe(new User(UserName: "Z"));
        using var newsSub_4 = newsFeed.Subscribe(new User(UserName: "W"));

        newsFeed.Publish(new NewsItem { Title = "Breaking News", Category = "World" });
        newsFeed.Publish(new NewsItem { Title = "Local News", Category = "City" });

        #endregion

        #region ISubject<T>
        ISubject<int> subject = new Subject<int>();

        var observer1 = new MySubjectObserver(observerName: "Observer 1");
        var observer2 = new MySubjectObserver(observerName: "Observer 2");

        IDisposable subscription1 = subject.Subscribe(observer1);
        IDisposable subscription2 = subject.Subscribe(observer2);

        subject.OnNext(10);
        subject.OnNext(20);
        subject.OnNext(30);

        subscription1.Dispose(); // Observer 1 artık bildirim almayacak
        subject.OnNext(40); // Sadece Observer 2 bu değeri alacak

        #endregion

    }
}


class MyObservable : IObservable<int>
{
    private List<IObserver<int>> observers = new List<IObserver<int>>();
    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);

        return new UnSubscription(() =>
        {
            observers.Remove(observer);
            observer.OnCompleted();
        });
    }
    public void Notify(int value) => observers.ForEach(o => o.OnNext(value));
}

class UnSubscription(Action unSubscription) : IDisposable
{
    public void Dispose()
    {
        unSubscription.Invoke();
        unSubscription = null;
    }
}

class MyObserver(string observerName) : IObserver<int>
{
    public void OnCompleted() => Console.WriteLine("Sequence completed." + observerName);
    public void OnError(Exception error) => Console.WriteLine("Error: " + error.Message + observerName);
    public void OnNext(int value) => Console.WriteLine("Received value: " + value + observerName);
}


#region Example


class NewsItem
{
    public string Title { get; set; }
    public string Category { get; set; }
}

class NewsFeed : IObservable<NewsItem>
{
    private List<IObserver<NewsItem>> observers = new List<IObserver<NewsItem>>();
    public IDisposable Subscribe(IObserver<NewsItem> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);

        return new UnSubscription(() =>
        {
            observers.Remove(observer);
            observer.OnCompleted();
        });
    }
    public void Publish(NewsItem item) => observers.ForEach(o => o.OnNext(item));
}

class User(string UserName) : IObserver<NewsItem>
{
    public void OnCompleted() => Console.WriteLine("No more news for " + UserName);
    public void OnError(Exception error) => Console.WriteLine("Error: " + error.Message + " for " + UserName);
    public void OnNext(NewsItem value) => Console.WriteLine($"New news item for {UserName}: {value.Title} in {value.Category}");
}

#endregion


#region ISubject<T>


class MySubjectObserver(string observerName) : IObserver<int>
{
    public void OnCompleted() => Console.WriteLine("Sequence completed." + observerName);
    public void OnError(Exception error) => Console.WriteLine("Error: " + error.Message + observerName);
    public void OnNext(int value) => Console.WriteLine("Received value: " + value + observerName);
}

#endregion