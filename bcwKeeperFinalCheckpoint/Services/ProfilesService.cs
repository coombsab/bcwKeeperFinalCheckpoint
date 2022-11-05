namespace bcwKeeperFinalCheckpoint.Services;

public class ProfilesService {
  private readonly ProfilesRepository _profilesRepository;

  public ProfilesService(ProfilesRepository profilesRepository)
  {
    _profilesRepository = profilesRepository;
  }

  public Profile GetUserProfile(string profileId) {
    return _profilesRepository.GetUserProfile(profileId);
  }

  public List<Keep> GetUserKeeps(string profileId) {
    return _profilesRepository.GetUserKeeps(profileId);
  }

  public List<Vault> GetUSerVaults(string profileId) {
    return _profilesRepository.GetUSerVaults(profileId);
  }
}