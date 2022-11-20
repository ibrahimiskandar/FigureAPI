using System.Drawing;

namespace FigureAPI.Models
{
    public abstract class Figure
    {
        private static int _id;
        public int Id { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public List<Point> Points { get; set; }
        public Point Center { get; set; }

        public Figure()
        {
        }

        public Figure(List<Point> points)
        {

            Id = Interlocked.Increment(ref _id);
            Points = points;
            FindCenter();
            CalculateArea();
            CalculatePerimeter();
        }

        public abstract void FindCenter();
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        public abstract void MoveFigure(double moveX, double moveY);
        public abstract void RotateFigure(double angle);
        public abstract void Scale(double scale);
    }
}

