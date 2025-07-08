





Console.WriteLine("Hello, World!");
MyMethod();

long a = 1234845643132123;
int b = 0;

b = (int)a;

int MyMethod()
{
    int x = 5;
    try
    {
        x++;
        throw new Exception();
    }
    catch
    {
        x++;
    }
    finally
    {
        x++;
    }
    return x;
}

