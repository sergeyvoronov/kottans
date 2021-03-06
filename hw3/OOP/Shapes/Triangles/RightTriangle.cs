﻿using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    /// Triangle with one 90 degrees corner
    /// </summary>
    public class RightTriangle : Triangle
    {
        public override string ShapeName { get; }
        public RightTriangle(double edge1, double edge2) : base(new Dictionary<ParamKeys, object>
        {
            {ParamKeys.Edge1, edge1},
            {ParamKeys.Edge2, edge2},
            {ParamKeys.Edge3, Math.Sqrt(edge1*edge1 + edge2*edge2)},
            {ParamKeys.CoordX, 0},
            {ParamKeys.CoordY, 0}
        })
        {
        }

        public RightTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double)parameters[ParamKeys.Edge1];
            _edge2 = (double)parameters[ParamKeys.Edge2];
            _edge3 = Math.Sqrt(_edge1 * _edge1 + _edge2 * _edge2);
            ShapeName = "RightTriangle";
        }
    }
}