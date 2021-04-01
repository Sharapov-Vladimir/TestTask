using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int Points = rand.Next(0, 1000);

            int Squares = 0;

            List<Point> PointsList = new List<Point>();

            for (int i = 0; i < Points; i++)
            {
                int x = rand.Next(0, 100);
                int y = rand.Next(0, 100);

                PointsList.Add(new Point(x, y));
            }

            var Xpoints = PointsList
                .GroupBy(point => point.X)
                .OrderBy(line => line.Key)
                .Select(l => l.ToList().Select(p => p.Y))
                .ToList();


            for (int i = 0; i < Xpoints.Count(); i++)
            {
                for (int u = Xpoints.Count()-1; u >i ; u--)
                {
                    Squares = Squares + GetSquares(Xpoints[i], Xpoints[u]);
                }
            }


            Console.WriteLine($"Общее количество точек : {Points}" + Environment.NewLine+$"Количество прямоугольников : {Squares}");
            Console.ReadKey();
        }

       private static int GetSquares (IEnumerable<int>first, IEnumerable<int> second)
        {
            int count = first.Intersect(second).Count();
            int result = 0;

            if (count<2)
            {
                return 0;
            }
            for (int i = count-1; i > 0; i--)
            {
                result = result + i;
            }
           
            return result;
        }
       
    }


    public class Point
    {
        public Point(int x , int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }

        public int Y { get; set; }

    }
}
