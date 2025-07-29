using System.Collections;
using System.ComponentModel;

#region What is this Iterator?


internal class Program
{
    private static void Main(string[] args)
    {
        Stock stock = new Stock();

        foreach (string material in stock)
        {
            Console.WriteLine(material);
        }
        #endregion


        #region Return yield

        foreach (var name in GetNames())
        {
            Console.WriteLine(name);
        }

        IEnumerable GetNames()
        {
            yield return "Alice";
            yield return "Bob";
            yield return "Charlie";
        }

        foreach (var setting in Settings())
        {
            Console.WriteLine($"{setting.key}: {setting.value}");
        }

        IEnumerable<(string key, string value)> Settings()
        {
            yield return ("Name", "Alice");
            yield return ("Age", "30");
            yield return ("Country", "USA");
        }
        #endregion

        #region yield deferred Execution
        IEnumerable<string> days = Days();

        foreach (var item in days)
        {
            Console.WriteLine(item);
        }


        IEnumerable<string> Days()
        {
            Console.WriteLine("Creating days collection");
            yield return "Monday";
            yield return "Tuesday";
            yield return "Wednesday";
            yield return "Thursday";
            yield return "Friday";
        }

        #endregion
    }
}

class Stock
{
    List<string> mateirlas = new() { "A", "B", "C", "D", "E" };

    public void AddMaterial(string material) => mateirlas.Add(material);

    public IEnumerator<string> GetEnumerator()
    {
        return mateirlas.GetEnumerator();
    }

}


