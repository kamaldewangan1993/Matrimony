using Matrimony.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilesController : Controller
    {
        private readonly MatrimonyContext _matrimonyContext;
        public ProfilesController(MatrimonyContext matrimonyContext)
        {
            _matrimonyContext = matrimonyContext;
        }

        // GET: ProfilesController
        [HttpGet(Name = "Index")]
        public ActionResult Index()
        {
            List<Profile> profiles = _matrimonyContext.Profiles.ToList();
            return Ok(profiles);
        }
    }
}
