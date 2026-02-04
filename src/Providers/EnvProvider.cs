namespace RymCloneApi.src.Providers;

using dotenv.net.Utilities;

public class EnvProvider
{
  private static EnvReader? _instance;
  public static EnvReader Instance
  {
    get
    {
      _instance ??= new EnvReader();
      return _instance;
    }
  }
}
