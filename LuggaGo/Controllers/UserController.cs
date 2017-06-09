using System.Threading.Tasks;
using System.Web.Http;
using LuggaGo.BindingModels;
using LuggaGo.BusinessLayer;
using LuggaGo.DataLayer.Models;
using LuggaGo.Models;
using Microsoft.AspNet.Identity;

namespace LuggaGo.Controllers
{
    public class UserController : ApiController
    {
        private readonly ApplicationUserManager _userManager;
        private readonly UserServices _userServices;

        public UserController(ApplicationUserManager userManager, UserServices userServices)
        {
            _userManager = userManager;
            _userServices = userServices;
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

            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            _userServices.AddUser(model.FirstName, model.LastName, appUser.Id);


            return Ok();
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
