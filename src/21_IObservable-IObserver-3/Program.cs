

NewsFeed newsFeed = new NewsFeed();

User user1 = new("Oguz");
User user2 = new("Burak");

using var user1Sub = newsFeed.Subscribe(user1);
using var user2Sub = newsFeed.Subscribe(user2);

newsFeed.PublishNews(new NewsItem { Category = "asdas", Title = "asdas" });
newsFeed.PublishNews(new NewsItem { Category = "axczx", Title = "zxczx" });




class NewsFeed : IObservable<NewsItem>
{

    List<IObserver<NewsItem>> observers = new();

    public IDisposable Subscribe(IObserver<NewsItem> observer)
    {
        if (!observers.Contains(observer)) observers.Add(observer);

        return new UnSubscription(() =>
        {

        });
        observers.Remove(observer);
        observer.OnCompleted();
    }

    public void PublishNews(NewsItem newsItem) => observers.ForEach(x => x.OnNext(newsItem));
}

class NewsItem
{
    public string Category { get; set; }
    public string Title { get; set; }
}

class UnSubscription(Action unsubscribe) : IDisposable
{
    public void Dispose()
    {
        unsubscribe?.Invoke();
        unsubscribe = null;
    }
}

class User(string userName) : IObserver<NewsItem>
{
    public void OnCompleted() => Console.WriteLine($"{userName}, news subscription completed.");


    public void OnError(Exception error) => Console.WriteLine($"{userName}, error : {error.Message}");

    public void OnNext(NewsItem value) => Console.WriteLine($"{userName}, news new in category {value.Category} : {value.Title}");
}