namespace BookShopSystem.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public abstract class BaseApiController : ApiController
    {
        protected IBookShopData data;

        protected BaseApiController(IBookShopData data)
        {
            this.data = data;
        }
    }
}