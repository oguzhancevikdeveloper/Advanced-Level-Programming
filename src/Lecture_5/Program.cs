// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MyMethod();

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

