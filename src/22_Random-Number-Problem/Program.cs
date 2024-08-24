using System.Security.Cryptography;

Random random = new Random();

for (int i = 0; i < 10; i++)
    Console.WriteLine(random.Next()); // Her çalıştığında farklı değer

Console.WriteLine("-----------------");

Random random1 = new Random(100);

for (int i = 0; i < 10; i++)
    Console.WriteLine(random1.Next()); // Her çalıştırdığımızda aynı değeri üretecek. Ama farklı pc lerde farklı değer :) ortama bağlı

Console.WriteLine("-----------------");

Random random2 = new Random(DateTime.UtcNow.Microsecond);
for (int i = 0; i < 10; i++)
    Console.WriteLine(random.Next()); // Her çalıştığında farklı değer

