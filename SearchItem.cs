using Quokka;
using Quokka.ListItems;
using System.Windows.Media.Imaging;

namespace Plugin_WebSearch {
  class SearchItem : ListItem {

    public string url;

    public SearchItem(String query) {
      this.url = $"https://www.startpage.com/do/dsearch?q={query}&cat=web&language=english";
      this.Name = $"Search for '{query}'";
      this.Description = $"Hit enter to open the search in your browser or open the context pane for a preview";
      this.Icon = new BitmapImage(new Uri(
          Environment.CurrentDirectory + "\\PlugBoard\\Plugin_WebSearch\\Plugin\\web.png"));
    }

    public override void Execute() {
      //open search in users browser
      App.Current.MainWindow.Close();
    }
  }
}
