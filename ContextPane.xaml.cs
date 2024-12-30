using Microsoft.Web.WebView2.Wpf;
using Quokka;
using Quokka.ListItems;
using System.Windows;

namespace Plugin_WebSearch {

  public partial class ContextPane : ItemContextPane {

    private readonly SearchItem Item;


    /// <summary>
    /// Context Pane
    /// </summary>
    public ContextPane() {
      InitializeComponent();
      Item = (SearchItem) ( (SearchWindow) Application.Current.MainWindow ).SelectedItem!;
      WebView2 WebBrowser = new();
      Pane.Child = WebBrowser;
      WebBrowser.Source = new Uri(Item.url);
    }
  }
}
