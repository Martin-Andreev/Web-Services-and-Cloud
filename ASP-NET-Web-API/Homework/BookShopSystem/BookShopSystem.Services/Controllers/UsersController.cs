namespace BookShopSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.ViewModels;

    [RoutePrefix("api/user")]
    public class UsersController : BaseApiController
    {
        [HttpGet]
        [Route("{username}/purchases")]
        public IHttpActionResult UserPurchases(string username)
        {
            var user = this.data
                .Users
                .All()
                .FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return this.BadRequest("User does not exist - invalid username!");
            }

            var purchases = this.data
                .Purchases
                .All()
                .Where(p => p.UserId == user.Id)
                .Select(PurchaseViewModel.ConvertToPurchaseViewModel)
                .OrderBy(p => p.DateOfPurchase);

            return this.Ok(purchases);
        }

        [HttpPut]
        [Route("{username}/roles")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddRole(string username, IdentityRole roleToAdd)
        {
            string loggedUserId = this.userIdProvider.GetUserId();
            var existingUser = this.data
                .Users
                .All()
                .FirstOrDefault(u => u.UserName == username);

            if (existingUser == null)
            {
                return this.BadRequest("User does not exist - invalid username.");
            }

            var loggedUser = this.data.Users.Find(loggedUserId);
            if (loggedUser == null)
            {
                return this.BadRequest("Invalid session token.");
            }

            var role = this.data
                .Roles
                .All()
                .FirstOrDefault(r => r.Name == roleToAdd.Name);

            if (role == null)
            {
                role = new IdentityRole
                {
                    Name = roleToAdd.Name
                };

                this.data.Roles.Add(role);
            }

            IdentityUserRole userRole = new IdentityUserRole
            {
                UserId = existingUser.Id,
                RoleId = role.Id
            };

            existingUser.Roles.Add(userRole);
            this.data.Save();

            return this.Ok();
        }

        [HttpDelete]
        [Route("{username}/roles")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult RemoveUserRole(string username, [FromBody]IdentityRole roleToRemove)
        {
            var existingUser = this.data
                .Users
                .All()
                .FirstOrDefault(u => u.UserName == username);

            if (existingUser == null)
            {
                return this.BadRequest("Invalid session token.");
            }

            var role = this.data
                .Roles
                .All()
                .FirstOrDefault(r => r.Name == roleToRemove.Name);
            
            if (role == null)
            {
                return this.BadRequest("Role does not exist - invalid role name.");
            }

            var userRole = existingUser
                .Roles
                .FirstOrDefault(u => u.RoleId == role.Id && u.UserId == existingUser.Id);

            existingUser.Roles.Remove(userRole);
            this.data.Save();

            return this.Ok();
        }
    }
}
