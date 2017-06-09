using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LuggaGo.BindingModels;
using LuggaGo.BusinessLayer;
using LuggaGo.DataLayer.Models;
using LuggaGo.DataLayer.Repositories;
using LuggaGo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LuggaGo.Controllers
{
    public class UserController : ApiController
    {
        private ApplicationUserManager _userManager;
        private UserServices _userServices;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public UserServices UserServices
        {
            get
            {
                return _userServices ?? new UserServices(new UserRepository());

            }
            private set { _userServices = value; }
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterUserBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            UserServices.AddUser(model.FirstName, model.LastName, appUser.Id);


            return Ok();
        }

        public List<User> GetUsers()
        {
            return UserServices.GetAll().ToList();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

    }
}
