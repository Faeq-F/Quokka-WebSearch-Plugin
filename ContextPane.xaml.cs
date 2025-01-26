using Extender;
using Quokka;
using Quokka.ListItems;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Plugin_WebSearch {

  public partial class ContextPane : ItemContextPane {

    private readonly SearchItem Item;


    /// <summary>
    /// Context Pane
    /// </summary>
    public ContextPane() {
      InitializeComponent();
      Item = (SearchItem) ( (SearchWindow) Application.Current.MainWindow ).SelectedItem!;
      var className = "ChromiumWebBrowser";
      var typeExtender = new TypeExtender(className);
      var returnedType = typeExtender.FetchType();
      //var obj = Activator.CreateInstance(returnedType);
      Control obj = (Control) WebSearch.CEFsharp!.CreateInstance("ChromiumWebBrowser");
      Pane.Child = obj;
      //PropertyInfo prop = returnedType.GetProperty("Address");
      //prop.SetValue(obj, new Uri(Item.url), null);


      PropertyInfo prop = obj.GetType().GetProperty("Address", BindingFlags.Public | BindingFlags.Instance);
      if (null != prop && prop.CanWrite) {
        prop.SetValue(obj, Item.url, null);
      }
    }
  }
}
