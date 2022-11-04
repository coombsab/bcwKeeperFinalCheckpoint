namespace bcwKeeperFinalCheckpoint.Services;

public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;

  public VaultsService(VaultsRepository vaultsRepository)
  {
    _vaultsRepository = vaultsRepository;
  }

  public Vault GetVaultById(int vaultId)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);
    if (vault == null) {
      throw new Exception("Could not find vault due to invalid ID.");
    }

    return vault;
  }

  public Vault GetVaultById(int vaultId, Account userInfo)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);
    if (vault == null) {
      throw new Exception("Could not find vault due to invalid ID.");
    }

    if (vault.isPrivate == true) {
      if (userInfo == null || vault.CreatorId != userInfo.Id) {
        throw new Exception("That vault is private and does not belong to you.");
      }
    }

    return vault;
  }

  public Vault CreateVault(Vault vaultData, string userId)
  {
    vaultData.CreatorId = userId;
    int vaultId = _vaultsRepository.CreateVault(vaultData);
    Vault vault = GetVaultById(vaultId);

    return vault;
  }

  public Vault EditVault(Vault vaultData, int vaultId, string userId)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userId) {
      throw new Exception("This is not your vault so you may not edit it.");
    }

    vault.Name = vaultData.Name ?? vault.Name;
    vault.Description = vaultData.Description ?? vault.Description;
    vault.Img = vaultData.Img ?? vault.Img;
    vault.isPrivate = vaultData.isPrivate ?? vault.isPrivate;

    return _vaultsRepository.EditVault(vault);
  }

  public Vault DeleteVault(int vaultId, string userId)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userId) {
      throw new Exception("This is not your vault so you may not delete it.");
    }

    _vaultsRepository.DeleteVault(vaultId);

    return vault;
  }
}