
internal class Program
{
    private static void Main(string[] args)
    {
        THandler<int, string, bool> tHandler1 = (a, b) =>
        {
            Console.WriteLine($"A: {a}, B: {b}");
            return true;
        };

        MyClass myClass = new MyClass();

        XHandler xHandler = new XHandler(new MyClass().MyMethod);
        XHandler xHandler1 = XMethod;

        XHandler xHandler2 = XMethod;
        xHandler2 += YMethod;

        xHandler2.GetInvocationList();

        XHandler xHandler3 = (a, b) =>
        {
            Console.WriteLine($"A: {a}, B: {b}");
        };

        XHandler xHandler4 = delegate (int a, string b)
        {
            Console.WriteLine($"A: {a}, B: {b}");
        };

        WHandler wHandler = (a, p) =>
        {
            Console.WriteLine($"A: {a}, P: {p}");
            return (1, 'c');
        };

        THandler tHandler = () =>
        {
            Console.WriteLine("THandler called");
            return true;
        };
        ZHandler zHandler = () =>
        {
            Console.WriteLine("ZHandler called");
        };

        xHandler3.Invoke(1, "Hello");

        void XMethod(int a, string b)
        {

        }
        void YMethod(int a, string b)
        {

        }
    }
}

public delegate T3 THandler<T1, T2, T3>(T1 a, T2 b);

public delegate void XHandler(int a, string b);

public delegate void YHandler(int a, string b, double c);

public delegate void ZHandler();

public delegate bool THandler();

public delegate (int, char) WHandler(A a, (string, int) p);

public class A { }

public class MyClass
{
    public void MyMethod(int param1, string param2)
    {

    }
}
