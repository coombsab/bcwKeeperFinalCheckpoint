namespace bcwKeeperFinalCheckpoint.Models;

public class Vault : DbItem<int>
{
  public string CreatorId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public bool? isPrivate { get; set; }

  //populated data
  public Profile Creator { get; set; }
}
