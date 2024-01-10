﻿namespace lab2.Shapes
{
    public interface IShape
    {
        public double CalculatePerimeter();
        public double CalculateArea();
        public void Draw(Graphics graphics);
    }
}
