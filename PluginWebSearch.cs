using Newtonsoft.Json;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.Collections.ObjectModel;
using System.IO;

namespace PluginWebSearch
{

  /// <summary>
  /// The Web Search plugin
  /// </summary>
  public class WebSearch : Plugin
  {

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluginName { get; set; } = "WebSearch";

    private static Settings pluginSettings = new();
    internal static Settings PluginSettings { get => pluginSettings; set => pluginSettings = value; }


    /// <summary>
    /// Loads plugin settings
    /// </summary>
    public WebSearch()
    {
      string fileName = Environment.CurrentDirectory + "\\PlugBoard\\PluginWebSearch\\Plugin\\settings.json";
      PluginSettings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(fileName))!;
    }


    private static Collection<ListItem> CreateItem(string query)
    {
      Collection<ListItem> items = new()
      {
        new SearchItem(query, pluginSettings.Browser, pluginSettings.SearchEngine)
      };
      return items;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="query"><inheritdoc/></param>
    /// <returns></returns>
    public override Collection<ListItem> OnQueryChange(string query)
    {
      return CreateItem(query);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>
    /// The Signifier from plugin settings
    /// </returns>
    public override Collection<string> CommandSignifiers()
    {
      return new Collection<string>() { PluginSettings.Signifier };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="command">The Signifier (Since there is only 1 signifier for this plugin), followed by the query being searched for</param>
    /// <returns>A search item to open the search in the user's browser</returns>
    public override Collection<ListItem> OnSignifier(string command)
    {
      command ??= "";
      command = command.Substring(PluginSettings.Signifier.Length);
      return CreateItem(command);
    }

  }
}
