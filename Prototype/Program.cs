using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

          Circle  figure1 = new Circle(5, 4,2);
            Circle clonedFigure1 = figure1.Clone() as Circle;

            figure1.GetInfo();
            clonedFigure1.GetInfo();
            Console.ReadKey();
        }
    }

    interface IFigure
    {
        IFigure Clone();
            void GetInfo();
    }
    class Rectangle :IFigure
    {
        int width;
        int height;

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Прямоугольник длиной {height} и высотой {width}");

        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Circle : IFigure
    {
        int radius;
        public  Point point {get; set; }

            public Circle(int r, int x, int y)
            {
                radius = r;
                this.point = new Point { X = x, Y = y };
            }

            public IFigure Clone()
            {
        return this.MemberwiseClone() as IFigure;
    }
            public void GetInfo()
            {
                Console.WriteLine($"Круг радиусом {radius} и центром в точке {point.X}, {point.X}");
            }
       
    }
}
