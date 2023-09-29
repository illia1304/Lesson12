﻿using System.Reflection.Metadata;
using System.Globalization;

namespace Lesson12
{
    public class Shape
    {
        public Shape(string name)
        {
            _name = name;
        }

        private string _name = string.Empty;
        public string Name => _name;
        public virtual float Area => 0;
        public virtual float Perimeter => 0;


    }
    public class Circle : Shape
    {
        public Circle(float radius)
            : base(nameof(Circle))
        {
            Radius = radius;
        }

        public float Radius { get; }

        public override float Perimeter => 2 * MathF.PI * Radius;

        public override float Area => MathF.PI * Radius * Radius;
    }

    public class Rectangle : Shape
    {
        public Rectangle(float width, float height)
            : base(nameof(Rectangle))
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }

        public float Height { get; }

        public override float Area => Width * Height;

        public override float Perimeter => 2 * (Width + Height);
    }
    public class Triangle : Shape
    {
        public Triangle(float a, float b, float c, float h)
            : base(nameof(Triangle))
        {
            A = a;
            H = h;
            B = b;
            C = c;
        }

        public float A { get; }
        public float B { get; }
        public float C { get; }
        public float H { get; }

        public override float Area => 0;
        public override float Perimeter => A + B + C;
    }

    public class RightTriangle : Triangle
    {
        public RightTriangle(float a, float b, float c, float h) :
            base(a, h, b, c)
        {

        }
        public override float Area => A * B;

    }

    public class EquilTriangle : Triangle
    {
        public EquilTriangle(float a, float b, float c, float h)
            : base(a, b, c, h)
        {

        }
        public override float Area => A * H;

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter count of shapes: ");
            int count = int.Parse(Console.ReadLine());

            Shape[] shapes = new Shape[count];
            for (int i = 0; i < count; i++)
            {
                shapes[i] = ReadShape();
            }

            float sum_area = 0;
            float sum_perimeters = 0;
            for (int i = 0; i < count; ++i)
            {
                sum_area += shapes[i].Area;
                sum_perimeters += shapes[i].Perimeter;
            }

            Console.WriteLine($"Total perimeter is {sum_perimeters}");
            Console.WriteLine($"Total area is {sum_area}");
        }
        static Shape ReadShape()
        {
            Console.WriteLine("Choose a shape type: ");
            Console.WriteLine("1.Circle");
            Console.WriteLine("2.Rectangle");
            Console.WriteLine("3.Triangle");
            Console.WriteLine("4.Right Triangle");
            Console.WriteLine("5.Equil Triangle");

        Read_Input:
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Enter circle radius: ");
                    float radius = float.Parse(Console.ReadLine());
                    return new Circle(radius);

                case 2:
                    Console.Write("Enter rectangle width: ");
                    float width = float.Parse(Console.ReadLine());
                    Console.Write("Enter rectangle height: ");
                    float height = float.Parse(Console.ReadLine());
                    return new Rectangle(width, height);
                case 3:
                    Console.Write("Enter triangle side A: ");
                    float a = float.Parse(Console.ReadLine());
                    Console.Write("Enter triangle side B: ");
                    float b = float.Parse(Console.ReadLine());
                    Console.Write("Enter triangle side C: ");
                    float c = float.Parse(Console.ReadLine());
                    Console.Write("Enter triangle triangle height: ");
                    float h = float.Parse(Console.ReadLine());
                    return new Triangle(a, b, c, h);

                case 4:

                    Console.Write("Enter right triangle side A: ");
                    a = float.Parse(Console.ReadLine());
                    Console.Write("Enter right triangle side B: ");
                    b = float.Parse(Console.ReadLine());
                    Console.Write("Enter right triangle side C: ");
                    c = float.Parse(Console.ReadLine());
                    Console.Write("Enter right triangle height: ");
                    h = float.Parse(Console.ReadLine());
                    return new RightTriangle(a, b, c, h);
                case 5:
                    Console.Write("Enter equilateral triangle side: ");
                    a = float.Parse(Console.ReadLine());
                    Console.Write("Enter right triangle height: ");
                    h = float.Parse(Console.ReadLine());
                    return new EquilTriangle(a, a, a, h);

                default:
                    Console.Write("Incorrect shape type. Choose again: ");
                    goto Read_Input;
            }
        }


    }
}