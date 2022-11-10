namespace bcwKeeperFinalCheckpoint.Services;

public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;
  private readonly VaultsService _vaultsService;
  private const int OFFSET_DEFAULT = 0;
  private const int LIMIT_DEFAULT = 100;

  public KeepsService(KeepsRepository keepsRepository, VaultsService vaultsService)
  {
    _keepsRepository = keepsRepository;
    _vaultsService = vaultsService;
  }

  public List<Keep> GetAllKeeps(string offsetStr, string limitStr, string search)
  {
    int offset = OFFSET_DEFAULT, limit = LIMIT_DEFAULT;
    if (offsetStr != null)
    {
      offset = int.Parse(offsetStr);
    }

    if (limitStr != null)
    {
      limit = int.Parse(limitStr);
    }

    if (search != null)
    {
      search = search.ToLower();
      return _keepsRepository.GetKeepsByTag(offset, limit, search);
    }

    return _keepsRepository.GetAllKeeps(offset, limit);
  }

  public Keep GetKeepById(int keepId)
  {
    Keep keep = _keepsRepository.GetKeepById(keepId);
    if (keep == null)
    {
      throw new Exception("Could not find keep due to invalid ID.");
    }

    return keep;
  }

  public Keep GetKeepByIdIncrementViews(int keepId)
  {
    Keep keep = _keepsRepository.GetKeepById(keepId);
    if (keep == null)
    {
      throw new Exception("Could not find keep due to invalid ID.");
    }

    keep.Views++;
    UpdateKeep(keep);

    return keep;
  }

  public List<KeepInVault> GetKeepsInVault(int vaultId, Account userInfo)
  {
    Vault vault = _vaultsService.GetVaultById(vaultId);
    if (vault.isPrivate == true)
    {
      if (userInfo == null || vault.CreatorId != userInfo.Id)
      {
        throw new Exception("This vault is private and you are not the creator.  Fare thee well!");
      }
    }
    return _keepsRepository.GetKeepsInVault(vaultId);
  }

  public Keep CreateKeep(Keep keepData, string userId)
  {
    keepData.CreatorId = userId;
    if (keepData.Tags != null)
    {
      keepData.Tags = keepData.Tags.ToUpper();
      string[] tags = keepData.Tags.Split(",");
      for (int i = 0; i < tags.Length; i++)
      {
        tags[i] = tags[i].Trim();
      }
      string[] tagsArr = tags.Distinct().ToArray();
      string processedTags = String.Join(",", tagsArr);
      keepData.Tags = processedTags;
    }

    int keepId = _keepsRepository.CreateKeep(keepData);
    Keep keep = GetKeepById(keepId);

    return keep;
  }

  public Keep EditKeep(Keep keepData, int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("This is not your keep so you may not edit it.");
    }

    if (keepData.Tags != null)
    {
      keepData.Tags = keepData.Tags.ToUpper();
      string[] tags = keepData.Tags.Split(",");
      for (int i = 0; i < tags.Length; i++)
      {
        tags[i] = tags[i].Trim();
      }
      string[] tagsArr = tags.Distinct().ToArray();
      string processedTags = String.Join(",", tagsArr);
      keepData.Tags = processedTags;
    }


    keep.Name = keepData.Name ?? keep.Name;
    keep.Description = keepData.Description ?? keep.Description;
    keep.Img = keepData.Img ?? keep.Img;
    keep.Tags = keepData.Tags ?? keep.Tags;

    return _keepsRepository.EditKeep(keep);
  }

  public void UpdateKeep(Keep keep)
  {
    _keepsRepository.EditKeep(keep);
  }

  public Keep DeleteKeep(int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("This is not your keep so you may not delete it.");
    }

    _keepsRepository.DeleteKeep(keepId);

    return keep;
  }
}