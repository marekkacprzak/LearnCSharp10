namespace Learn10.Assignment_and_declaration_in_same_deconstruction;

public class Assignment_and_declaration_in_same_deconstruction
{
    private record Point(int X, int Y);
    public static void Test()
    {
        var point = new Point(23, 23);
        // Initialization:
        (var x, var y) = point;
        var x1 = 0;
        var y1 = 0;
        (x1, y1) = point;
        var x2 = 0;
        (x2, var y2) = point;
        Console.WriteLine("(x2, var y2) = point");
    }
}