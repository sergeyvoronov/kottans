using System;
using System.Collections.Generic;
namespace OOP.Shapes
{
	public class Circle : ShapeBase
	{
        double _radius;

        public Circle(double radius)
            : this(new Dictionary<ParamKeys, object> { 
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

		public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
		{
            _radius = (double) parameters[ParamKeys.Radius];
		}

	    public override double GetPerimeter()
	    {
	        throw new NotImplementedException();
	    }

	    protected override double Area()
	    {
	        throw new NotImplementedException();
	    }

	    public override void Move(int deltaX, int deltaY)
	    {
	        throw new NotImplementedException();
	    }

	    public override string ShapeName { get; }
	}
}