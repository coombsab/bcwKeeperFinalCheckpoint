namespace bcwKeeperFinalCheckpoint.Models;

public class Keep : DbItem<int>
{
  public string CreatorId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public string Tags { get; set; }

  // populated data
  public int Kept { get; set; }
  public Profile Creator { get; set; }
}
