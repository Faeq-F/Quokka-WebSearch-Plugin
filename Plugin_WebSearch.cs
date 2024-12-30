
using Quokka.ListItems;
using Quokka.PluginArch;

namespace Plugin_WebSearch {

  /// <summary>
  /// The Web Search plugin
  /// </summary>
  public class WebSearch : Plugin {

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluggerName { get; set; } = "WebSearch";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="query"><inheritdoc/></param>
    /// <returns></returns>
    public override List<ListItem> OnQueryChange(string query) {
      List<ListItem> items = new();
      items.Add(new SearchItem(query));
      return items;
    }
  }

}
