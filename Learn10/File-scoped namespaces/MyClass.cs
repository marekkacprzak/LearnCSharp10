// Program.cs
global using System;
global using System.Collections.Generic;
// MyFile.cs
namespace Learn10.File_scoped_namespaces; //C# 10.0

class File_scoped_namespaces
{
    public static void Test()
    {
        List<int> myList = new();
        myList.Add(1);
        myList.Add(2);
        Console.WriteLine(myList.Count);
    }
    // ...
}