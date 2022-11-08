namespace bcwKeeperFinalCheckpoint.Services;

public class ProfilesService {
  private readonly ProfilesRepository _profilesRepository;

  public ProfilesService(ProfilesRepository profilesRepository)
  {
    _profilesRepository = profilesRepository;
  }

  public Profile GetUserProfile(string profileId) {
    Profile profile = _profilesRepository.GetUserProfile(profileId);
    if (profile == null) {
      throw new Exception("Could not find profile likely due to an invalid ID.");
    }
    return profile;
  }

  public List<Keep> GetUserKeeps(string profileId) {
    return _profilesRepository.GetUserKeeps(profileId);
  }

  public List<Vault> GetUSerVaults(string profileId) {
    return _profilesRepository.GetUSerVaults(profileId);
  }
}