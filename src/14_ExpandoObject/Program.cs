
#region What is ExpandoObject?

dynamic expandoObject = new ExpandoObject();

expandoObject.Name = "John";
expandoObject.Surname = "Doe";
expandoObject.Age = 30;
expandoObject.Address = "123 Main St";
expandoObject.phoneNumber = "123-456-7890";

expandoObject.YearOfBirth = new Func<int>(() => DateTime.Now.Year - expandoObject.Age);


IDictionary<string, object> expandoDict = (IDictionary<string, object>)expandoObject;

foreach (KeyValuePair<string, object> item in expandoDict)
    Console.WriteLine($"{item.Key}: {item.Value}");

expandoDict.Add("Married", true);

#endregion

#region Serialization of ExpandoObject

dynamic person1 = new ExpandoObject();
person1.Name = "Alice";
person1.Surname = "Smith";
person1.Age = 28;

dynamic person2 = new ExpandoObject();
person2.Name = "Bob";
person2.Surname = "Johnson";
person2.Age = 35;

dynamic person3 = new ExpandoObject();
person3.Name = "Charlie";
person3.Surname = "Brown";
person3.Age = 22;

List<ExpandoObject> list = new List<ExpandoObject>()
{
    person1,
    person2,
    person3
};

var jsonData = JsonSerializer.Serialize(list);

Console.WriteLine(jsonData);

#endregion

#region Deserialization of ExpandoObject

List<ExpandoObject> deserializedList = JsonSerializer.Deserialize<List<ExpandoObject>>(jsonData)!;

#endregion
