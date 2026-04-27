using System.IO;
using CL_Shape;

public class Triangle : Shape
{
    private double a, b;

    public void Set(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override string ToString()
    {
        return $"Трикутник.\n" +
               $"Катет 1: {a}\n" +
               $"Катет 2: {b}\n" +
               $"Площа: {Area():F2}";
    }

    public override double Area()
    {
        return a * b * 0.5;
    }

    public override void Save(string fileName)
    {
        File.WriteAllText(fileName, $"{a};{b}");
    }

    public override void Load(string fileName)
    {
        var data = File.ReadAllText(fileName).Split(';');
        a = double.Parse(data[0]);
        b = double.Parse(data[1]);
    }
}