using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFeatures {

    struct Point {
        public double X;
        public double Y;
        public override string ToString() {
            return "(" + X + ", " + Y + ")";
        }
        public double DistanceFrom(Point point) {
            var XDiff = point.X - this.X;
            var YDiff = point.Y - this.Y;
            return Math.Sqrt(XDiff * XDiff + YDiff * YDiff);
        }
    }

    class Colors {
        public string FillColor { get; set; }
        public string BorderColor { get; set; }
    }

    struct Rectangle {
        public Point point1;
        public Point point2;
        public Point point3;
        public Point point4;
        public Colors colors;
        public override string ToString() {
            return String.Format("Point1 : {0}\nPoint2 : {1}\nPoint3 : {2}\nPoint4 : {3}\nFillColor : {4}\nBorderColor : {5}\n",
                point1, point2, point3, point4, colors.FillColor, colors.BorderColor);
        }
    }

    class Structures {

        //will not work since value is passed instead of reference for structures
        static void ResetPoint(Point point) {
            point.X = 0;
            point.Y = 0;
        }

        public static void Main() {

            Point point1;
            point1.X = 0;
            //Console.WriteLine(point1); //error
            point1.Y = 0;

            Point point2;
            point2.X = 0;
            point2.Y = 5;

            Point point3 = new Point { X = 5, Y = 5 };
            Point point4 = new Point();

            Console.WriteLine("Point 1 : {0}", point1);
            Console.WriteLine("Point 2 : {0}", point2);
            Console.WriteLine("Point 3 : {0}", point3);
            Console.WriteLine("Distance between {0} and {1} is {2}",point1,point2,point1.DistanceFrom(point2));
            Console.WriteLine("Distance between {0} and {1} is {2}", point2, point3, point2.DistanceFrom(point3));

            ResetPoint(point2);
            Console.WriteLine("Point 2 after reset : {0}", point2);

            //equal since values are compared
            Console.WriteLine(point1.Equals(point4));

            //X and Y values of point3 are copied to point4
            point4 = point3;
            point4.X = 6;
            Console.WriteLine("Point 3 : {0}, Point 4 : {1}",point3,point4);

            Console.WriteLine();

            Rectangle rect1 = new Rectangle {
                point1 = new Point(),
                point2 = new Point { X = 0, Y = 5 },
                point3 = new Point { X = 5, Y = 5 },
                point4 = new Point { X = 5, Y = 0 },
                colors = new Colors {
                    FillColor="Yellow",
                    BorderColor="Blue"
                }
            };

            //all valuetype properties will be copied
            //for referencetype properties, both objects will share the same reference
            Rectangle rect2 = rect1;
            rect2.point3 = new Point { X = 6, Y = 6 };
            rect2.colors.FillColor = "Red";

            Console.WriteLine(rect1);
            Console.WriteLine(rect2);

            Console.ReadLine();
        }
    }
}
