namespace bcwKeeperFinalCheckpoint.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Keep> GetAllKeeps(int offset, int limit)
  {
    string sql = @"
      SELECT
        k.*,
        a.*,
        COUNT(vk.id) AS Kept
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      LEFT JOIN vaultKeeps vk ON vk.keepId = k.id
      GROUP BY k.id
      LIMIT @limit
      OFFSET @offset;
    ";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
      keep.Creator = profile;
      return keep;
    }, new { offset, limit }).ToList();
  }

  // TODO figure out how to get the where to allow through everything if search is empty
  public List<Keep> GetKeepsByTag(int offset, int limit, string search)
  {
    search = $"%{search}%";
    string sql = @"
      SELECT
        k.*,
        a.*,
        COUNT(vk.id) AS Kept
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      LEFT JOIN vaultKeeps vk ON vk.keepId = k.id
      WHERE LOWER(k.tags) LIKE @search
      GROUP BY k.id
      LIMIT @limit
      OFFSET @offset;
    ";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
      keep.Creator = profile;
      return keep;
    }, new { offset, limit, search }).ToList();
  }

  public Keep GetKeepById(int keepId)
  {
    string sql = @"
      SELECT
        k.*,
        a.*,
        COUNT(vk.id) AS Kept
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      LEFT JOIN vaultKeeps vk ON vk.keepId = k.id
      WHERE k.id = @keepId
      GROUP BY k.id
    ";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
      keep.Creator = profile;
      return keep;
    }, new { keepId }).FirstOrDefault();
  }

  public int CreateKeep(Keep keepData)
  {
    string sql = @"
      INSERT INTO keeps (
        creatorId, name, description, img, views
      )
      VALUES (
        @CreatorId, @Name, @Description, @Img, @Views
      );
      SELECT LAST_INSERT_ID();
    ";

    return _db.ExecuteScalar<int>(sql, keepData);
  }

  public Keep EditKeep(Keep keep)
  {
    string sql = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        tags = @Tags
      WHERE id = @Id
      LIMIT 1;
    ";
    int rows = _db.Execute(sql, keep);
    if (rows < 1) {
      throw new Exception("Changes to keep were not saved.");
    }

    if (rows > 1) {
      throw new Exception("Something went wrong with editing the keep.  Please contact your DBA.");
    }
    
    return keep;
  }

  public void DeleteKeep(int keepId)
  {
    string sql = @"
      DELETE FROM keeps
      WHERE id = @keepId
      LIMIT 1
    ";

    int rows = _db.Execute(sql, new { keepId });
    if (rows < 1) {
      throw new Exception("Keep was not deleted.");
    }
    if (rows > 1) {
      throw new Exception("Something went wrong with deleting the keep.  Please contact your DBA.");
    }
  }
}