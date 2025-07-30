using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Collection Initialization
        int[] numbers = new int[3] { 1, 2, 3 };
        List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };

        #endregion


        #region How to create a custom collection

        MyClass _numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        #endregion


        #region Example of using the custom collection



        Example example = new Example(){
                                { 3, true, "Alice" },
                                { 4, false, "Bob" },
                                { 5, true, "Charlie" }};
    }
    #endregion
}




#region How to create a custom collection

class MyClass : IEnumerable<int>
{
    private List<int> _items = new List<int>();

    public int MyProperty { get; set; }
    public int MyProperty1 { get; set; }
    public int MyProperty2 { get; set; }

    public void Add(int item) => _items.Add(item);

    public IEnumerator<int> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

}

#endregion


#region Example of using the custom collection

class Example : IEnumerable<int>
{
    private List<int> _items = new List<int>();
    public int MyProperty { get; set; }
    public int MyProperty1 { get; set; }
    public int MyProperty2 { get; set; }
    public void Add(int item, bool result, string who) => _items.Add(item);

    public void Add(int item) => _items.Add(item);

    public IEnumerator<int> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
}

#endregion


