using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double lenght;
        
    public double Lenght
    {
        get { return lenght; }
        set { lenght = value; }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }

    public double SurfaceArea(Box box)
    {
       return  2 * box.Lenght * Width + 2 * Lenght * Height + 2 * Width * Height;
    }

    public double LateralSurfaceArea(Box box)
    {
        return 2 * Lenght * Height + 2 * Width * Height;
    }

    public double Volume(Box box)
    {
        return  Lenght * Width * Height;
    }
}

