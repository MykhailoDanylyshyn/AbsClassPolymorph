using System;
using System.IO;
using CL_Shape;

class ApplicationInterface
{
    static void Main()
    {
        string fileName = "figures.txt";

        if (!File.Exists(fileName))
        {
            CollectionOfFigures initCollection = new CollectionOfFigures();

            Triangle t = new Triangle();
            t.Set(3, 4);

            Rectangle r = new Rectangle();
            r.Set(0, 0, 5, 5);

            Circle c = new Circle();
            c.Set(0, 0, 3);

            initCollection.Add(t);
            initCollection.Add(r);
            initCollection.Add(c);

            initCollection.Save(fileName);
        }

        CollectionOfFigures collection = new CollectionOfFigures();
        collection.Load(fileName);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== МЕНЮ =====");
            Console.WriteLine("1 - Додати трикутник");
            Console.WriteLine("2 - Додати прямокутник");
            Console.WriteLine("3 - Додати коло");
            Console.WriteLine("4 - Показати всі фігури");
            Console.WriteLine("5 - Площі всіх фігур");
            Console.WriteLine("6 - Зберегти у файл");
            Console.WriteLine("7 - Завантажити з файлу");
            Console.WriteLine("0 - Вихід");
            Console.Write("Вибір: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("Катет a: ");
                            if (!double.TryParse(Console.ReadLine(), out double a))
                            {
                                Console.WriteLine("Помилка вводу!");
                                break;
                            }

                            Console.Write("Катет b: ");
                            if (!double.TryParse(Console.ReadLine(), out double b))
                            {
                                Console.WriteLine("Помилка вводу!");
                                break;
                            }

                            Shape s = new Triangle();
                            ((Triangle)s).Set(a, b);
                            collection.Add(s);
                            break;
                        }

                    case "2":
                        {
                            Console.Write("x1: ");
                            if (!double.TryParse(Console.ReadLine(), out double x1)) { Console.WriteLine("Помилка!"); break; }

                            Console.Write("y1: ");
                            if (!double.TryParse(Console.ReadLine(), out double y1)) { Console.WriteLine("Помилка!"); break; }

                            Console.Write("x2: ");
                            if (!double.TryParse(Console.ReadLine(), out double x2)) { Console.WriteLine("Помилка!"); break; }

                            Console.Write("y2: ");
                            if (!double.TryParse(Console.ReadLine(), out double y2)) { Console.WriteLine("Помилка!"); break; }

                            Shape s = new Rectangle();
                            ((Rectangle)s).Set(x1, y1, x2, y2);
                            collection.Add(s);
                            break;
                        }

                    case "3":
                        {
                            Console.Write("x: ");
                            if (!double.TryParse(Console.ReadLine(), out double x)) { Console.WriteLine("Помилка!"); break; }

                            Console.Write("y: ");
                            if (!double.TryParse(Console.ReadLine(), out double y)) { Console.WriteLine("Помилка!"); break; }

                            Console.Write("r: ");
                            if (!double.TryParse(Console.ReadLine(), out double r)) { Console.WriteLine("Помилка!"); break; }

                            Shape s = new Circle();
                            ((Circle)s).Set(x, y, r);
                            collection.Add(s);
                            break;
                        }

                    case "4":
                        collection.PrintAll();
                        break;

                    case "5":
                        collection.AreaAll();
                        break;

                    case "6":
                        collection.Save(fileName);
                        Console.WriteLine("Збережено.");
                        break;

                    case "7":
                        collection.Load(fileName);
                        Console.WriteLine("Завантажено.");
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}