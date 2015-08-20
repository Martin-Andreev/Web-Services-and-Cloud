namespace BookShopSystem.Services.Controllers
{
    using System.Web.Http;
    using Data;
    using Infrastructure;

    public abstract class BaseApiController : ApiController
    {
        protected IBookShopData data;
        protected IUserIdProvider userIdProvider;

        protected BaseApiController()
            :this(new BookShopData(), new AspNetUserIdProvider())
        {
            
        }

        protected BaseApiController(IBookShopData data, IUserIdProvider userIdProvider)
        {
            this.data = data;
            this.userIdProvider = userIdProvider;
        }
    }
}