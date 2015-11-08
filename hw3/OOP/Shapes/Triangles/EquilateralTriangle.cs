using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double edge1) : base(new Dictionary<ParamKeys, object>
        {
            {ParamKeys.Edge1, edge1},
            {ParamKeys.Edge2, edge1},
            {ParamKeys.Edge3, edge1},
            {ParamKeys.CoordX, 0},
            {ParamKeys.CoordY, 0}
        })
        {
        }

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = _edge1;
            _edge3 = _edge1;
            ShapeName = "EquilateralTriangle";
        }

        public override string ShapeName { get; }
    }
}
