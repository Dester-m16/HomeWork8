using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeProgram
{
    abstract class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double Area();
        public abstract double Perimeter();
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Square : Shape
    {
        public double Side { get; set; }

        public Square(string name, double side) : base(name)
        {
            Side = side;
        }

        public override double Area()
        {
            return Math.Pow(Side, 2);
        }

        public override double Perimeter()
        {
            return 4 * Side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for shape {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Shape (C for Circle, S for Square): ");
                string shapeType = Console.ReadLine();

                if (shapeType.Equals("C", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    shapes.Add(new Circle(name, radius));
                }
                else if (shapeType.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Side: ");
                    double side = double.Parse(Console.ReadLine());
                    shapes.Add(new Square(name, side));
                }
                else
                {
                    Console.WriteLine("Invalid shape type. Skipping shape...");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Shape details:");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Name: {shape.Name}");
                Console.WriteLine($"Area: {shape.Area()}");
                Console.WriteLine($"Perimeter: {shape.Perimeter()}");
                Console.WriteLine();
            }

            double largestPerimeter = 0;
            string shapeWithLargestPerimeter = "";

            foreach (Shape shape in shapes)
            {
                if (shape.Perimeter() > largestPerimeter)
                {
                    largestPerimeter = shape.Perimeter();
                    shapeWithLargestPerimeter = shape.Name;
                }
            }

            Console.WriteLine($"Shape with the largest perimeter: {shapeWithLargestPerimeter}");

            shapes.Sort((shape1, shape2) => shape1.Area().CompareTo(shape2.Area()));

            Console.WriteLine("Shapes sorted by area:");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Name: {shape.Name}");
                Console.WriteLine($"Area: {shape.Area()}");
                Console.WriteLine();
            }
        }
    }
}