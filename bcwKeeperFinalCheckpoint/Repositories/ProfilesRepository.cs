namespace bcwKeeperFinalCheckpoint.Repositories;

public class ProfilesRepository {
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  public Profile GetUserProfile(string profileId) {
    string sql = @"
      SELECT * FROM accounts
      WHERE id = @profileId;
    ";

    return _db.QueryFirstOrDefault<Profile>(sql, new { profileId });
  }

  public List<Keep> GetUserKeeps(string profileId) {
    string sql = @"
      SELECT k.*, a.* FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      WHERE k.creatorId = @profileId
    ";
    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
      keep.Creator = profile;
      return keep;
    }, new { profileId }).ToList();
  }

  public List<Vault> GetUSerVaults(string profileId) {
    string sql = @"
      SELECT v.*, a.* FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.creatorId = @profileId AND v.isPrivate = 0
    ";

    return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {
      vault.Creator = profile;
      return vault;
    }, new { profileId }).ToList();;
  }
}