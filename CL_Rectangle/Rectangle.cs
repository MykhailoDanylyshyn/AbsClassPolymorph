using System;
using System.IO;
using CL_Shape;

public class Rectangle : Shape
{
    private double x1, y1, x2, y2;

    public void Set(double x1, double y1, double x2, double y2)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public override string ToString()
    {
        return $"Прямокутник.\n" +
               $"Лівий верхній кут: ({x1}; {y1})\n" +
               $"Правий нижній кут: ({x2}; {y2})\n" +
               $"Площа: {Area():F2}";
    }

    public override double Area()
    {
        double width = Math.Abs(x2 - x1);
        double height = Math.Abs(y2 - y1);
        return width * height;
    }

    public override void Save(string fileName)
    {
        File.WriteAllText(fileName, $"{x1};{y1};{x2};{y2}");
    }

    public override void Load(string fileName)
    {
        var data = File.ReadAllText(fileName).Split(';');
        x1 = double.Parse(data[0]);
        y1 = double.Parse(data[1]);
        x2 = double.Parse(data[2]);
        y2 = double.Parse(data[3]);
    }
}