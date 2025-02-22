using Quokka;
using Quokka.ListItems;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Plugin_WebSearch {
  class SearchItem : ListItem {

    public string url;
    public string browser;

    public SearchItem(String query, String browser, String searchEngine) {
      this.browser = browser;
      if (query.StartsWith("https://") || query.StartsWith("http://") || query.StartsWith("www.")) {
        this.url = query;
      } else {
        this.url = searchEngine + query;
      }
      this.Name = $"Search for '{query}'";
      this.Description = $"Hit enter to open the search in your browser";
      this.Icon = new BitmapImage(new Uri(
          Environment.CurrentDirectory + "\\PlugBoard\\Plugin_WebSearch\\Plugin\\web.png"));
    }

    public override void Execute() {
      //open search in users browser
      Process.Start(browser + url);
      App.Current.MainWindow.Close();
    }

  }
}
