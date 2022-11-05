namespace bcwKeeperFinalCheckpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase {
  private readonly Auth0Provider _auth0Provider;
  private readonly KeepsService _keepsService;

  public KeepsController(Auth0Provider auth0Provider, KeepsService keepsService)
  {
    _auth0Provider = auth0Provider;
    _keepsService = keepsService;
  }

  [HttpGet]
  public ActionResult<List<Keep>> GetAllKeeps([FromQuery] string offset, [FromQuery] string limit, string search) {
    try {
      List<Keep> keeps = _keepsService.GetAllKeeps(offset, limit, search);
      return Ok(keeps);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{keepId}")]
  public ActionResult<Keep> GetKeepById(int keepId) {
    try {
      Keep keep = _keepsService.GetKeepByIdIncrementViews(keepId);
      return Ok(keep);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.CreateKeep(keepData, userInfo.Id);
      return Ok(keep);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{keepId}")]
  [Authorize]
  public async Task<ActionResult<Keep>> GetEditKeep([FromBody] Keep keepData, int keepId) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.EditKeep(keepData, keepId, userInfo.Id);
      return Ok(keep);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{keepId}")]
  [Authorize]
  public async Task<ActionResult<Keep>> GetDeleteKeep(int keepId) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.DeleteKeep(keepId, userInfo.Id);
      return Ok(keep);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

}