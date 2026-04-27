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
            Console.WriteLine("6 - Видалити фігуру");
            Console.WriteLine("7 - Показати усі фігури обраного типу");
            Console.WriteLine("8 - Показати площі фігур обраного типу");
            Console.WriteLine("9 - Зберегти у файл");
            Console.WriteLine("10 - Завантажити з файлу");
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

                            Triangle t = new Triangle();
                            t.Set(a, b);
                            collection.Add(t);
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

                            Rectangle r = new Rectangle();
                            r.Set(x1, y1, x2, y2);
                            collection.Add(r);
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

                            Circle c = new Circle();
                            c.Set(x, y, r);
                            collection.Add(c);
                            break;
                        }

                    case "4":
                        collection.PrintAll();
                        break;

                    case "5":
                        collection.AreaAll();
                        break;

                    case "6":
                        {
                            Console.Write("Індекс для видалення: ");
                            if (int.TryParse(Console.ReadLine(), out int index))
                            {
                                collection.Remove(index);
                            }
                            else
                            {
                                Console.WriteLine("Помилка вводу!");
                            }
                            break;
                        }

                    case "7":
                        {
                            Console.WriteLine("Оберіть тип фігури:");
                            Console.WriteLine("1 - Трикутник");
                            Console.WriteLine("2 - Прямокутник");
                            Console.WriteLine("3 - Коло");
                            Console.Write("Вибір: ");

                            string typeChoice = Console.ReadLine();

                            switch (typeChoice)
                            {
                                case "1":
                                    collection.PrintByType<Triangle>();
                                    break;

                                case "2":
                                    collection.PrintByType<Rectangle>();
                                    break;

                                case "3":
                                    collection.PrintByType<Circle>();
                                    break;

                                default:
                                    Console.WriteLine("Невірний вибір типу.");
                                    break;
                            }

                            break;
                        }

                    case "8":
                        {
                            Console.WriteLine("Оберіть тип фігури:");
                            Console.WriteLine("1 - Трикутник");
                            Console.WriteLine("2 - Прямокутник");
                            Console.WriteLine("3 - Коло");
                            Console.Write("Вибір: ");

                            string typeChoice = Console.ReadLine();

                            switch (typeChoice)
                            {
                                case "1":
                                    collection.AreaByType<Triangle>();
                                    break;

                                case "2":
                                    collection.AreaByType<Rectangle>();
                                    break;

                                case "3":
                                    collection.AreaByType<Circle>();
                                    break;

                                default:
                                    Console.WriteLine("Невірний вибір типу.");
                                    break;
                            }

                            break;
                        }

                    case "9":
                        collection.Save(fileName);
                        Console.WriteLine("Збережено.");
                        break;

                    case "10":
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