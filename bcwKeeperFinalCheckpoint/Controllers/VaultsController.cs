namespace bcwKeeperFinalCheckpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase {
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultsService _vaultsService;

  public VaultsController(Auth0Provider auth0Provider, VaultsService vaultsService)
  {
    _auth0Provider = auth0Provider;
    _vaultsService = vaultsService;
  }

  [HttpGet("{vaultId}")]
  public async Task<ActionResult<Vault>> GetVaultById(int vaultId) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetVaultById(vaultId, userInfo);
      return Ok(vault);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.CreateVault(vaultData, userInfo.Id);
      return Ok(vault);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<Vault>> EditVault([FromBody] Vault vaultData, int vaultId) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.EditVault(vaultData, vaultId, userInfo.Id);
      return Ok(vault);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<Vault>> DeleteVault(int vaultId) {
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.DeleteVault(vaultId, userInfo.Id);
      return Ok(vault);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}