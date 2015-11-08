using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OOP.Shapes
{
    public class Circle : ShapeBase
    {
        double _radius;

        public double Radius => Multiplier*_radius;
      
        public Circle(double radius, byte multiplier =  1)
            : this(new Dictionary<ParamKeys, object> {
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {      
        }

        public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {    
            _radius = (double)parameters[ParamKeys.Radius];
            if (Multiplier == 0) Multiplier = 1;
            ShapeName = "Circle";
        }

        
        public override double GetPerimeter()
        {
            return
                2 * Radius * Math.PI;
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }

        public override string ShapeName { get; }

        protected override double Area()
        {
            return
               Radius * Radius * Math.PI;
        }

        public override string ToString()
        {
            return $"Shape information: Name : {ShapeName}, X : {0}, Y : {0}, Perimeter : {2 * Radius * Math.PI}, Square : {Radius* Radius* Math.PI}";
        }
    }
}