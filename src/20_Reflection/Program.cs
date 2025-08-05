using System.Reflection;
using System.Reflection.Emit;

#region Assembly Bilgisi Alma

Assembly assembly = Assembly.GetExecutingAssembly();
Assembly assembly1 = Assembly.Load("20_Reflection");

#endregion

#region Assembly Üzerinden Tip Bilgilerini Listeleme

var _type = assembly.GetTypes();

foreach (Type type in assembly.GetTypes())
{
    Console.WriteLine($"Type: {type.Name}");

    foreach (PropertyInfo property in type.GetProperties())
        Console.WriteLine($"  Property: {property.Name}, Type: {property.PropertyType}");

    foreach (MethodInfo method in type.GetMethods())
        Console.WriteLine($"  Method: {method.Name}, Return Type: {method.ReturnType}");
}

#endregion

#region Type Alma (Instance ve typeof)

MyClass myClass = new MyClass();

Type myClassType = myClass.GetType();
var t = nameof(myClassType);

Type myClassType2 = typeof(MyClass);

#endregion

#region Üye Bilgileri ve Reflection Üzerinden Erişim

MemberInfo[] members = myClassType2.GetMembers();

MethodInfo methodInfo = myClassType2.GetMethod(nameof(MyClass));
methodInfo.Invoke(myClass, null); // constructor çağrısı gibi görünse de aslında bu metot bulamaz (düzenlenebilir)

PropertyInfo[] propertyInfo = myClassType2.GetProperties();
propertyInfo.FirstOrDefault().SetValue(myClass.MyProperty, 5); // Hatalı kullanım (MyProperty nesne değil int bekler)

FieldInfo[] fieldInfos = myClassType2.GetFields();
FieldInfo fieldInfos2 = myClassType2.GetField(nameof(myClass.MyProperty2));

#endregion

#region DynamicMethod ve ILGenerator Kullanımı

DynamicMethod dynamicMethod = new DynamicMethod("DynamicMethod", typeof(void), null); // void döner, parametre yok
ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
iLGenerator.Emit(OpCodes.Ldarg_0); // boş çünkü parametre yok
iLGenerator.Emit(OpCodes.Ret);

Func<int, int, int> _delegate = (Func<int, int, int>)dynamicMethod.CreateDelegate(typeof(Func<int, int, int>));
_delegate.Invoke(5, 10);

#endregion

#region BindingFlags Kullanımı

Type type1 = typeof(MyClass);
var methods = type1.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance); // Tüm private instance üyeler

#endregion

#region Sınıf Tanımı

class MyClass
{
    public int MyProperty { get; set; }
    public int MyProperty2 { get; set; }

    public void MyMethod()
    {
        Console.WriteLine("MyMethod called");
    }
}

#endregion

