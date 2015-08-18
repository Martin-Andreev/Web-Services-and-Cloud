namespace Distance_Calculator.Client
{
    using System;
    using System.Net;

    public class DistanceCalculatorClient
    {
        public static void Main()
        {
            using (WebClient client = new WebClient())
            {
                var response = client.UploadString("http://localhost:5427/distance?startX=5&startY=5&endX=10&endY=10", "POST");

                Console.WriteLine(response);
            }
        }
    }
}
