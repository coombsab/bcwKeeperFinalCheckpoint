namespace bcwKeeperFinalCheckpoint.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsService vaultsService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _vaultsService = vaultsService;
  }

  public VaultKeep GetVaultKeepById(int vaultKeepId) {
    VaultKeep vaultKeep = _vaultKeepsRepository.GetVaultKeepById(vaultKeepId);
    if (vaultKeep == null) {
      throw new Exception("Cannot find VaultKeep due to invalid ID.");
    }

    return vaultKeep;
  }

  public VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
  {
    Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId);
    if (vault.CreatorId != userId) {
      throw new Exception("You cannot add keeps to a vault that is not yours.");
    }

    vaultKeepData.CreatorId = userId;
    int vaultKeepId = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);
    VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

    return vaultKeep;
  }

  public VaultKeep DeleteVaultKeep(int vaultKeepId, string userId)
  {
    VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);
    if (vaultKeep.CreatorId != userId) {
      throw new Exception("This is not your VaultKeep so you may not delete it.");
    }

    _vaultKeepsRepository.DeleteVaultKeep(vaultKeepId);

    return vaultKeep;
  }
}