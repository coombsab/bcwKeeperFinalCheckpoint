namespace bcwKeeperFinalCheckpoint.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    if (original.Name == null)
    {
      original.Name = editData.Name;
    }
    else
    {
      original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    }
    if (original.Picture == null)
    {
      original.Picture = editData.Picture;
    }
    else
    {
      original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    }
    if (original.Bio == null)
    {
      original.Bio = editData.Bio;
    }
    else
    {
      original.Bio = editData.Bio.Length > 0 ? editData.Bio : original.Bio;
    }
    if (original.Hobbies == null)
    {
      original.Hobbies = editData.Hobbies;
    }
    else
    {
      original.Hobbies = editData.Hobbies.Length > 0 ? editData.Hobbies : original.Hobbies;
    }
    if (original.CoverImg == null)
    {
      original.CoverImg = editData.CoverImg;
    }
    else
    {
      original.CoverImg = editData.CoverImg.Length > 0 ? editData.CoverImg : original.CoverImg;
    }

    return _repo.Edit(original);
  }

  public void Delete(string accountId)
  {
    _repo.Delete(accountId);
  }
}
