using System;

namespace Factory_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Shape shape1 = ShapeFactory.GetShape(ShapeType.Circle);
            shape1.Draw();
            Shape shape2 = ShapeFactory.GetShape(ShapeType.Rectangle);
            shape2.Draw();
            Shape shape3 = ShapeFactory.GetShape(ShapeType.Square);
            shape3.Draw();
            Shape shape4 = ShapeFactory.GetShape(ShapeType.Triangle);
            shape4.Draw();
            Console.ReadKey();
        }
    }
    public interface Shape
    {
        void Draw();
    }
    public class Rectangle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("绘制矩形");
        }
    }
    public class Square : Shape
    {
        public void Draw()
        {
            Console.WriteLine("绘制正方形");
        }
    }
    public class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("绘制圆形");

        }
    }
    public class Triangle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("绘制三角形");

        }
    }
    public enum ShapeType
    {
        Rectangle,
        Square,
        Circle,
        Triangle

    }
    public class ShapeFactory
    {
        public static Shape GetShape(ShapeType shapetype)
        {
            if (shapetype == ShapeType.Circle)
            {
                return new Circle();
            }
            else if (shapetype == ShapeType.Rectangle)
            {
                return new Rectangle();
            }
            else if (shapetype == ShapeType.Triangle)
            {
                return new Triangle();
            }
            else
            {
                return new Square();
            }

        }
    }
}
