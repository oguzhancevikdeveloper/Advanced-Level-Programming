﻿
Console.WriteLine("Hello, World!");

int _a = 5;

ref var __a = ref X(ref _a);

Console.WriteLine(_a);
Console.WriteLine(__a);

Console.ReadLine();
ref int X(ref int a)
{
    a = 0;
    return ref a;
}

Console.WriteLine("--------------------------------");

int b = 5;
ref int c = ref Y(ref b);

Console.WriteLine(b); //132
c = 123123;
Console.WriteLine(c); //123123


Console.ReadLine();
ref int Y(ref int a)
{
    a = 132;
    //int y =0;
    //return ref y;  // böyle bir kullanım yok dönecekd referans global olmak zorunda.
    return ref a;
}