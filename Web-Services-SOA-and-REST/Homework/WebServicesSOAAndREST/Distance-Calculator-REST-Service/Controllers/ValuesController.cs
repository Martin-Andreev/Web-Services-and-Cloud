namespace Distance_Calculator_REST_Service.Controllers
{
    using System;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        [Route("distance")]
        public double CalculateDistance(int startX, int startY, int endX, int endY)
        {
            int deltaX = startX - endX;
            int deltaY = startY - endY;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
