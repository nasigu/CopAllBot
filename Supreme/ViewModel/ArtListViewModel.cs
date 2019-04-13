using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Supreme.Core;
using Supreme.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Visibility = System.Windows.Visibility;

namespace Supreme.ViewModel
{
    public class ArtListViewModel : BaseListViewModel<Art>
    {


        public ArtListViewModel()
        {
            LoadArtListAsync();
        }

       
        private static readonly string Extension = "https";
        private static readonly string Site = "www.supremenewyork.com";
        private static readonly string ShopAllAddress = $"{Extension}://{Site}/shop/all";

        public ObservableCollection<ArtList> ArtsList { get; set; }
        public NotifyTaskCompletion<IDocument> HtmlDocument { get; private set; }

        #region Method
      

        public void LoadArtListAsync()
        {
            string Source = DownloadHtml(ShopAllAddress);
            var Items = new ObservableCollection<ArtList>();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var Parser = new HtmlParser();
            var Document = Parser.ParseDocument(Source);
            var ListSelector = "div[id=\"container\"] > article > div[class = \"inner-article\"] > a[href]";
            var ImgTag = "IMG";
            var AllArtsList = Document.QuerySelectorAll(ListSelector);
            var ItemsCount = AllArtsList.Length;

            foreach (var art in AllArtsList)
            {
                var ImageElement = art.GetElementsByTagName(ImgTag);
                var SoldOutTag = art.GetElementsByClassName("sold_out_tag").Length == 0 ? false : true;
                var ImageReference = ImageElement[0].GetAttribute("src");

                Items.Add(new ArtList { Reference = art.GetAttribute("href"), Image = "https:" + ImageReference, SoldOut = SoldOutTag, SoldOutVisibility = Visibility.Hidden });
            }

            ArtsList = Items;
        }

        private ICommand _DoSomethingCommand;
        public ICommand DoSomethingCommand
        {
            get { return _DoSomethingCommand ?? (_DoSomethingCommand = new ActCommand(DoSomething)); }


        }

        private void DoSomething()
        {
            Trace.WriteLine("FSDFS");
        }

        //private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    var Item = (Grid)sender;
        //    var ArtItem = Item.DataContext as ArtList;
        //    if (ArtItem.SoldOut)
        //    {
        //        ArtItem.SoldOutVisibility = Visibility.Visible;
        //    }
        //}

        //private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    var Item = (Grid)sender;
        //    var ArtItem = Item.DataContext as ArtList;
        //    if (ArtItem.SoldOut)
        //    {
        //        ArtItem.SoldOutVisibility = Visibility.Hidden;
        //    }
        //}

        #endregion Method

    }


}
