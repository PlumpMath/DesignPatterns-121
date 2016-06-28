using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AllIn.CreationalPatterns
{
    /*
    Когда конкретный тип создаваемого объекта должен определяться динамически во время выполнения

    Когда нежелательно создание отдельной иерархии классов фабрик для создания объектов-продуктов из
        параллельной иерархии классов(как это делается, например, при использовании паттерна Абстрактная фабрика)

    Когда клонирование объекта является более предпочтительным вариантом нежели его создание 
        и инициализация с помощью конструктора.Особенно когда известно, что объект может принимать небольшое 
            ограниченное число возможных состояний.
    */

    class Prototype
    {
        //Prototype
        public interface IFigure
        {
            IFigure CloneFigure();
            void GetInfo();
        }

        //Concrete PrototypeA
        public class Rectangle : IFigure
        {
            public int Height { get; set; }

            public int Width { get; set; }

            public Rectangle(int height, int width)
            {
                Height = height;
                Width = width;
            }

            public IFigure CloneFigure() => new Rectangle(Height,Width);

            public void GetInfo() => Console.WriteLine($"Прямоугольник высотой {Height} шириной {Width}");
        }

        //Concrete PrototypeB
        public class Circle : IFigure
        {
            public int Radius { get; set; }

            public Circle(int radius)
            {
                Radius = radius;
            }

            public IFigure CloneFigure() => new Circle(Radius);

            public void GetInfo() => Console.WriteLine($"Круг с радиусом {Radius}");
        }
    }

    /*
    static void Main(string[] args)
    {
        IFigure figure = new Rectangle(30, 40);
        IFigure clonedFigure = figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();
 
        figure = new Circle(30);
        clonedFigure=figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();
    */
    }
