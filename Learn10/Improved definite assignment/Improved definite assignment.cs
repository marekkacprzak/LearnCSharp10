namespace Learn10.Improved_definite_assignment;

public class Improved_definite_assignment
{
    public static void Test()
    {
        var representation = "N/A";
     
        var c=new C();
        if ((c != null && c.GetDependentValue(out object obj)) == true)
        {
            representation = obj.ToString(); // undesired error in C# 9.0
        }
        if (c?.GetDependentValue(out object obj1) == true)
        {
            representation = obj1.ToString(); // undesired error C# 9.0
        }
        if (c?.GetDependentValue(out object obj2) ?? false)
        {
            representation = obj2.ToString(); // undesired error C# 9.0
        }
    }

    private class C
    {
        public bool GetDependentValue(out object obj)
        {
            obj = 2;
            return true;
        }
    }
}