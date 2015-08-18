namespace Distance_Calculator_Client
{
    using System;
    using ServiceReferenceDistance;

    public class DistanceCalculatorClient
    {
        public static void Main()
        {
            DistanceServiceClient calculator = new DistanceServiceClient();
            Point startPoint = new Point() { x = 10, y = 10};
            Point endPoint = new Point() { x = 15, y = 15};
            var distance = calculator.CalculateDistance(startPoint, endPoint);

            Console.WriteLine(distance);

        }
    }
}
