namespace PluginWebSearch
{
  /// <summary>
  /// All plugin specific settings
  /// </summary>
  public class Settings
  {
    /// <summary>
    /// The command signifier used to obtain a search item (defaults to "? ")
    ///</summary>
    public string Signifier { get; set; } = "? ";
    /// <summary>
    /// The command to use the user's browser (defaults to "microsoft-edge:")
    /// <br />
    /// The URL of the search query will be appended to this
    /// </summary>
    public string Browser { get; set; } = "microsoft-edge:";
    /// <summary>
    /// The URL to use the user's search engine (defaults to "https://www.bing.com/search?q=")
    /// <br />
    /// the search query will be appended to this
    /// </summary>
    public string SearchEngine { get; set; } = "https://www.bing.com/search?q=";
  }


}
