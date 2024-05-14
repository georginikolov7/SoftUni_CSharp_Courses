using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_ClassBoxData
{
    public class Box
    {
        private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Height)));
                }
                height = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Width)));
                }
                width = value;
            }
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Length)));
                }
                length = value;
            }
        }
        private double SurfaceArea()
        {
            double baseArea = CalculateBaseArea();
            double lateralSurfaceArea = LateralSurfaceArea();
            return lateralSurfaceArea + 2 * baseArea;
        }
        private double LateralSurfaceArea()
        {
            return 2 * (length + width) * height;
        }
        private double Volume()
        {
            return CalculateBaseArea() * height;
        }
        private double CalculateBaseArea()
        {
            return length * width;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");
            return sb.ToString().Trim();
        }
    }
}
