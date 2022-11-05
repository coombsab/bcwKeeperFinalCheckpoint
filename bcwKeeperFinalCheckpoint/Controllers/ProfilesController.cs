namespace bcwKeeperFinalCheckpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase {
  private readonly ProfilesService _profilesService;

  public ProfilesController(ProfilesService profilesService)
  {
    _profilesService = profilesService;
  }

  [HttpGet("{profileId}")]
  public ActionResult<Profile> GetUserProfile(string profileId) {
    try {
      Profile profile = _profilesService.GetUserProfile(profileId);
      return Ok(profile);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]
  public ActionResult<List<Keep>> GetUserKeeps(string profileId) {
    try {
      List<Keep> keeps = _profilesService.GetUserKeeps(profileId);
      return Ok(keeps);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public ActionResult<List<Vault>> GetUserVaults(string profileId) {
    try {
      List<Vault> vaults = _profilesService.GetUSerVaults(profileId);
      return Ok(vaults);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}