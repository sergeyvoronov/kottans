using System;

public class NotAShipException : Exception
{
	public NotAShipException()
	{
	    message = "Not a ship";
	}
}
