using System;
using System.IO;
using CL_Shape;

public class Circle : Shape
{
    private double x, y, r;

    public void Set(double x, double y, double r)
    {
        this.x = x;
        this.y = y;
        this.r = r;
    }

    public override string ToString()
    {
        return $"Коло.\n" +
               $"Центр: ({x}, {y})\n" +
               $"Радіус: {r}\n" +
               $"Площа: {Area():F2}";
    }

    public override double Area()
    {
        return Math.PI * r * r;
    }

    public override void Save(string fileName)
    {
        File.WriteAllText(fileName, $"{x};{y};{r}");
    }

    public override void Load(string fileName)
    {
        var data = File.ReadAllText(fileName).Split(';');
        x = double.Parse(data[0]);
        y = double.Parse(data[1]);
        r = double.Parse(data[2]);
    }
}