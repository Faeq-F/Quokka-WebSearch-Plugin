using Newtonsoft.Json;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.IO;

namespace Plugin_WebSearch {

  /// <summary>
  /// The Web Search plugin
  /// </summary>
  public class WebSearch : Plugin {

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluggerName { get; set; } = "WebSearch";

    private static Settings pluginSettings = new();
    internal static Settings PluginSettings { get => pluginSettings; set => pluginSettings = value; }


    /// <summary>
    /// Loads plugin settings
    /// </summary>
    public WebSearch() {
      string fileName = Environment.CurrentDirectory + "\\PlugBoard\\Plugin_WebSearch\\Plugin\\settings.json";
      PluginSettings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(fileName))!;
    }


    private List<ListItem> createItem(string query) {
      List<ListItem> items = new();
      items.Add(new SearchItem(query, pluginSettings.Browser, pluginSettings.SearchEngine));
      return items;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="query"><inheritdoc/></param>
    /// <returns></returns>
    public override List<ListItem> OnQueryChange(string query) {
      return createItem(query);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>
    /// The Signifier from plugin settings
    /// </returns>
    public override List<string> CommandSignifiers() {
      return new List<string>() { PluginSettings.Signifier };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="command">The Signifier (Since there is only 1 signifier for this plugin), followed by the query being searched for</param>
    /// <returns>A search item to open the search in the user's browser</returns>
    public override List<ListItem> OnSignifier(string command) {
      command = command.Substring(PluginSettings.Signifier.Length);
      return createItem(command);
    }

  }
}
