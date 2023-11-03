namespace Learn10.Constant_interpolated_strings;

public class Constant_interpolated_strings
{
    public static void Test()
    {
        const string Language = "C#";
        const string Platform = ".NET";
        const string Version = "10.0";
        const string FullProductName = $"{Platform} - Language: {Language} Version: {Version}"; //C# 10.0
        Console.WriteLine(FullProductName);
        //Constant_interpolated_strings.MyConstant = 3; //error this is const
    }
}