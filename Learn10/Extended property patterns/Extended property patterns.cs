namespace Learn10.Extended_property_patterns;

public class Extended_property_patterns
{
    public static void Test()
    {
        var person = new Person
        {
            Name = "John Doe",
            Address = new Address
            {
                Street = "123 Main Street",
                City = "Anytown",
                State = "CA"
            }
        };

        // C# 9.0
        if (person.Address is Address address && address.City == "Anytown" && address.State == "CA")
        {
            // ...
        }

        // C# 10.0
        if (person is Person { Address: { City: "Anytown", State: "CA" }})
        {
            // ...
        }
        const string Language = "C#";
        const string Platform = ".NET";
        const string Version = "10.0";
        const string FullProductName = $"{Platform} - Language: {Language} Version: {Version}";

    }
}

public struct Person
{
    public string Name { get; set; }
    public Address Address { get; set; }
}

public struct Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}


public class Example
{
    public static void Ma3in()
    {
       
    }
}