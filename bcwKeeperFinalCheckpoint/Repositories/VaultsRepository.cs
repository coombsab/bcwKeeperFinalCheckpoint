namespace bcwKeeperFinalCheckpoint.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Vault GetVaultById(int vaultId)
  {
    string sql = @"
      SELECT
        v.*,
        a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @vaultId;
    ";
    return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { vaultId }).FirstOrDefault();
  }

  public int CreateVault(Vault vaultData)
  {
    string sql = @"
      INSERT INTO vaults (
        creatorId, name, description, img, isPrivate
      )
      VALUES (
        @CreatorId, @Name, @Description, @Img, @IsPrivate
      );
      SELECT LAST_INSERT_ID();
    ";

    return _db.ExecuteScalar<int>(sql, vaultData);
  }

  public Vault EditVault(Vault vault)
  {
    string sql = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = IsPrivate
      WHERE id = @Id
      LIMIT 1;
    ";

    int rows = _db.Execute(sql, vault);
    if (rows < 1)
    {
      throw new Exception("Changes to vault were not saved.");
    }

    if (rows > 1)
    {
      throw new Exception("Something went wrong with editing the vault.  Please contact your DBA.");
    }

    return vault;
  }

  public void DeleteVault(int vaultId)
  {
    string sql = @"
      DELETE FROM vaults
      WHERE id = @vaultId
      LIMIT 1;
    ";

    int rows = _db.Execute(sql, new { vaultId });
    if (rows < 1)
    {
      throw new Exception("Vault was not deleted.");
    }

    if (rows > 1)
    {
      throw new Exception("Something went wrong with deleting the vault.  Please contact your DBA.");
    }
  }
}