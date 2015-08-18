namespace Distance_Calculator_SOAP_Service
{
    using System;
    using System.Drawing;

    public class DistanceCalculator : IDistanceService
    {
        public double CalculateDistance(Point startPoint, Point endPoint)
        {
            int deltaX = startPoint.X - endPoint.X;
            int deltaY = startPoint.Y - endPoint.Y;

            return Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
        }
    }
}
