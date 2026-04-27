using System;
using System.IO;
using CL_Shape;

public class CollectionOfFigures
{
    private Shape[] figures = new Shape[0];

    public void Add(Shape shape)
    {
        Array.Resize(ref figures, figures.Length + 1);
        figures[figures.Length - 1] = shape;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= figures.Length)
        {
            Console.WriteLine("Невірний індекс.");
            return;
        }

        for (int i = index; i < figures.Length - 1; i++)
            figures[i] = figures[i + 1];

        Array.Resize(ref figures, figures.Length - 1);
    }

    public void PrintAll()
    {
        foreach (var f in figures)
        {
            f.Show();
            Console.WriteLine();
        }
    }

    public void PrintByType<T>() where T : Shape
    {
        foreach (var f in figures)
        {
            if (f is T)
            {
                f.Show();
                Console.WriteLine();
            }
        }
    }

    public void AreaAll()
    {
        foreach (var f in figures)
        {
            Console.WriteLine($"{f.GetType().Name}: {f.Area():F2}");
        }
    }

    public void AreaByType<T>() where T : Shape
    {
        foreach (var f in figures)
        {
            if (f is T)
            {
                Console.WriteLine($"{f.GetType().Name}: {f.Area():F2}");
            }
        }
    }

    public void Save(string fileName)
    {
        using StreamWriter sw = new StreamWriter(fileName);

        int counter = 0;

        foreach (var f in figures)
        {
            string tempFile = $"{fileName}_temp_{counter++}.txt";

            sw.WriteLine(f.GetType().Name);

            f.Save(tempFile);
            sw.WriteLine(File.ReadAllText(tempFile));

            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
    }

    public void Load(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        figures = new Shape[0];

        string[] lines = File.ReadAllLines(fileName);

        for (int i = 0; i < lines.Length - 1; i += 2)
        {
            string type = lines[i];
            string data = lines[i + 1];

            Shape shape = type switch
            {
                "Triangle" => new Triangle(),
                "Rectangle" => new Rectangle(),
                "Circle" => new Circle(),
                _ => null
            };

            if (shape != null)
            {
                string tempFile = $"{fileName}_loadtemp_{i}.txt";

                File.WriteAllText(tempFile, data);
                shape.Load(tempFile);

                if (File.Exists(tempFile))
                    File.Delete(tempFile);

                Add(shape);
            }
        }
    }
}