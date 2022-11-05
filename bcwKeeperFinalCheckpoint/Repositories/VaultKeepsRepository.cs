namespace bcwKeeperFinalCheckpoint.Repositories;

public class VaultKeepsRepository {
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  public VaultKeep GetVaultKeepById(int vaultKeepId) {
    string sql = @"
      SELECT * FROM vaultKeeps
      WHERE id = @vaultKeepId;
    ";

    return _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
  }

  public int CreateVaultKeep(VaultKeep vaultKeepData) {
    // TODO Why can't I do this check?  Maybe user is allowed to add the same keep more than once?
    // if (CheckIfVaultKeepExists(vaultKeepData.VaultId, vaultKeepData.KeepId)) {
    //   throw new Exception("This keep is already in this vault.");
    // }

    string sql = @"
      INSERT INTO vaultKeeps (
        creatorId, vaultId, keepId
      )
      VALUES (
        @CreatorId, @VaultId, @KeepId
      );
      SELECT LAST_INSERT_ID();
    ";

    int vaultKeepId = _db.ExecuteScalar<int>(sql, vaultKeepData);
    return vaultKeepId;
  }

  public void DeleteVaultKeep(int vaultKeepId) {
    string sql = @"
      DELETE FROM vaultKeeps
      WHERE id = @vaultKeepId
      LIMIT 1;
    ";

    int rows = _db.Execute(sql, new { vaultKeepId });

    if (rows < 1)
    {
      throw new Exception("VaultKeep was not deleted.");
    }

    if (rows > 1)
    {
      throw new Exception("Something went wrong with deleting the VaultKeep.  Please contact your DBA.");
    }
  }

  private bool CheckIfVaultKeepExists(int vaultId, int keepId) {
    string sql = @"
      SELECT * FROM vaultKeeps
      WHERE vaultId = @vaultId AND keepID = @keepId;
    ";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultId, keepId }).FirstOrDefault();
    if (vaultKeep == null) {
      return false;
    }
    
    return true;
  }
}