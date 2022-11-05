namespace bcwKeeperFinalCheckpoint.Models;

public class VaultKeep : DbItem<int>
{
  public string CreatorId { get; set; }
  public int VaultId { get; set; }
  public int KeepId { get; set; }
}