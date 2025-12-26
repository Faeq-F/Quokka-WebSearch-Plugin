using Quokka;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.Diagnostics;

namespace PluginWebSearch
{
  class SearchItem : ListItem
  {

    public string url;
    public string browser;

    public SearchItem(String query, String browser, String searchEngine)
    {
      this.browser = browser;
      if (query.StartsWith("https://", StringComparison.Ordinal) || query.StartsWith("http://", StringComparison.Ordinal) || 
        query.StartsWith("www.", StringComparison.Ordinal))
      {
        this.url = query;
      }
      else
      {
        this.url = searchEngine + query;
      }
      Name = $"Search for '{query}'";
      Description = $"Hit enter to open the search in your browser";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginWebSearch\\Plugin\\web.png"
      );
    }

    public override void Execute()
    {
      //open search in users browser
      Process.Start(browser + url);
      App.Current.MainWindow.Close();
    }

  }
}
