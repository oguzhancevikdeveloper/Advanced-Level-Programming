using System.Reflection;
using System.Text.Json.Serialization;




#region Example


Assembly assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes()
    .Where(t => t.GetCustomAttribute<My3Attribute>() is not null)
    .ToList();

foreach (var type in types)
{
    Console.WriteLine(type.GetCustomAttribute<My3Attribute>()!.Description);
}




[AttributeUsage(AttributeTargets.Class)]
class My3Attribute : Attribute
{
    public string Description { get; set; }

}


[My3(Description = nameof(MyClass3))]
class MyClass3 { }



class MyClass4 { }

[My3(Description = nameof(MyClass5))]
class MyClass5 { }




#endregion


#region Atribute Kullanımı


//[assembly: AssemblyTitle("ozi")] // bunu ya burada kullancaksın ya da AssemblyInfo.cs dosyasında kullanacaksın
[AttributeUsage(AttributeTargets.All)]
class My2Attribute : Attribute
{
    public My2Attribute(int i) { }

    public int MyProperty { get; set; }
    public int MyProperty1 { get; set; }
    public int MyProperty2 { get; set; }
    public int j;

    public void MyMethod() { }
}

[AttributeUsage(AttributeTargets.All)]
class MyAttribute : Attribute
{
    public MyAttribute(int i) { }

    public int MyProperty { get; set; }
    public int MyProperty1 { get; set; }
    public int MyProperty2 { get; set; }
    public int j;

    public void MyMethod() { }
}


[My2(7, MyProperty2 = 7)]
[My(5, MyProperty2 = 5, MyProperty = MyConst)]
class MyClass2
{
    private const int MyConst = 5; // const  olması şart attr vermke için

    [My(5, MyProperty1 = 7)]
    public MyClass2() { }

    public void X() { }

    [My(5)]
    public int MyProperty { get; set; }
}


[JsonSerializable(typeof(MyClass))]
class MyClass { }

#endregion