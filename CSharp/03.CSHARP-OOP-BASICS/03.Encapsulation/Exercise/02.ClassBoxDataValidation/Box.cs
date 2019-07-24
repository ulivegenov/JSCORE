using System;
using System.Collections.Generic;
using System.Text;


class Box
{
    private double lenght;

    public double Lenght
    {
        get { return lenght; }
        private set
        {
            lenght = ValidateSide(value, "Length");
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        private set
        {
            width = ValidateSide(value, "Width");
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        private set
        {
            height = ValidateSide(value, "Height");
        }
    }

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }

    public double SurfaceArea(Box box)
    {
        return 2 * box.Lenght * Width + 2 * Lenght * Height + 2 * Width * Height;
    }

    public double LateralSurfaceArea(Box box)
    {
        return 2 * Lenght * Height + 2 * Width * Height;
    }

    public double Volume(Box box)
    {
        return Lenght * Width * Height;
    }

    private double ValidateSide(double sideLenght, string sideName)
    {
        if (sideLenght > 0)
        {
            return sideLenght;
        }
        else
        {
            throw new ArgumentException($"{sideName} cannot be zero or negative.");
        }
    }
}

