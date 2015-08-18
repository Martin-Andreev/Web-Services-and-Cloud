namespace Distance_Calculator_SOAP_Service
{
    using System.Drawing;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDistanceService
    {

        [OperationContract]
        double CalculateDistance(Point startPoint, Point endPoint);

    }
}
