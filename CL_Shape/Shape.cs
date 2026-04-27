using System;

namespace CL_Shape
{
    public abstract class Shape
    {
        public void Show()
        {
            Console.WriteLine(ToString());
        }

        public abstract double Area();

        public abstract void Save(string fileName);
        public abstract void Load(string fileName);
    }
}