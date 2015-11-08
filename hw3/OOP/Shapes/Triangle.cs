using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OOP.Shapes
{
    // TODO: use Heron's formula for area
    public class Triangle : ShapeBase
    {
        public double _edge1 = 0, _edge2 = 0, _edge3 = 0;

        public override string ShapeName { get; }

        public Triangle(double edge1, double edge2, double edge3) : this(new Dictionary<ParamKeys, object>
        {
            {ParamKeys.Edge1, edge1},
            {ParamKeys.Edge2, edge2},
            {ParamKeys.Edge3, edge3 },
            {ParamKeys.CoordX, 0 },
            {ParamKeys.CoordY, 0 }
        })
        { }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = (double) parameters[ParamKeys.Edge3];
            if (Multiplier == 0) Multiplier = 1;
            ShapeName = "Triangle";
        }

        public override double GetPerimeter()
        {
            return (_edge1 + _edge2 + _edge3) * Multiplier;
        }

        protected override double Area()
        {
            var p = (_edge1 + _edge2 + _edge3) / 2;
            return Multiplier * Math.Sqrt(p * (p - _edge1) * (p - _edge2) * (p - _edge3));
        }

        public override void Move(int deltaX, int deltaY)
        {
            CoordX += deltaX;
            CoordY += deltaY;
        }
    }
}