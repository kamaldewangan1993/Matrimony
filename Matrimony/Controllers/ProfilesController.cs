using Matrimony.Business.Interface;
using Matrimony.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET: ProfilesController
        [HttpGet(Name = "Index")]
        public ActionResult Index()
        {
            
            List<ProfileViewModel> profiles = _profileService.GetProfiles();
            return Ok(profiles);
        }

        [HttpPost(Name = "Create")]
        public ActionResult Create(ProfileViewModel profileViewModel)
        {
            int? result = _profileService.CreateProfile(profileViewModel);
            return Ok(result);
        }

        [HttpPut(Name = "Edit")]
        public ActionResult Edit(ProfileViewModel profileViewModel)
        {

            int? result = _profileService.EditProfile(profileViewModel);
            return Ok(result);
        }

        [HttpDelete(Name = "Delete")]
        public ActionResult Delete(int? id)
        {
            int? result = _profileService.DeleteProfile(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("Demo")]
        public ActionResult Demo()
        {
            return Ok("Azure Deployment working successfully");
        }
    }
}
