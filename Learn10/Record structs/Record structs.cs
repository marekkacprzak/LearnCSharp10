namespace Learn10.Record_structs;

public class Record_structs
{
    public record struct DataMeasurement(DateTime TakenAt, double Measurement);//c 10.0

    private readonly struct Point
    {
        public Point(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        } 
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
    }

    public static void Test()
    {
        var point = new Point(10, 20, 30);
        var newPoint = point with { X = 15 }; //C 10.0
        Console.WriteLine("public record struct DataMeasurement(DateTime TakenAt)");
    }
    
    public readonly struct Measurement
    {
        public Measurement() // .net 10 Parameterless struct constructors
        {
            Value = double.NaN;
            Description = "Undefined";
        }

        public Measurement(double value, string description)
        {
            Value = value;
            Description = description;
        }

        private double Value { get; init; }
        private string Description { get; init; }

        public override string ToString() => $"{Value} ({Description})";
    }
}