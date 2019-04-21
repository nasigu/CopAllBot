using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Supreme.Core;
using Supreme.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class TestViewModel: BaseItemViewModel<Test>
    {
        #region Constructor

        public TestViewModel(Test item): base(item)
        {
            //Item = item;
            //AddToBasket();
        }

        public TestViewModel(): base(new Test())
        {
            //Item = item;
            //AddToBasket();
        }

        #endregion Constructor

        #region Property

        public ObservableCollection<Test> Test { get; set; }
            IConfiguration config = Configuration.Default.WithDefaultLoader();



        #endregion Property


        #region Command

        private ICommand _AddToBasketCommand;
        public ICommand AddToBasketCommand { get { return _AddToBasketCommand ?? (_AddToBasketCommand = new ActCommand(GetDocument)); } }

        #endregion Command

        #region Method

        async void fd()
        {
          var d = await SendAddToBasketRequestAsync(); 
          
        }

        async Task<string> SendAddToBasketRequestAsync()
        {
            var dict = new Dictionary<string, string>();
            string url = "https://www.supremenewyork.com/shop/304209/add";
            dict.Add("urf8", "%E2%9C%93");
            dict.Add("style", "25801");
            dict.Add("size", "55214");
            dict.Add("commit", "add to basket");
            var xCSRFToken = "UEr1o5K8sG5V252eXER39Nq+/3275tn913tGY7X3NdVwzV7QtcndIn+SfTbonyn8y2nketCRVUiFwNIqK51EBA==";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "*/*;q=0.5, text/javascript, application/javascript, application/ecmascript, application/x-ecmascript");
                client.DefaultRequestHeaders.Add("x-csrf-token", xCSRFToken);
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");                
                HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(dict));
                return response.Content.ReadAsStringAsync().Result; ;               
            }
        }


        static async void MaindAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6740");
            //    var content = new FormUrlEncodedContent(new[]
            //    {
            //    new KeyValuePair<string, string>("", "login")
            //});
            //var content = new F

                //var result = await client.PostAsync("/api/Membership/exists", content);
                //string resultContent = await result.Content.ReadAsStringAsync();
                //Console.WriteLine(resultContent);
            }
        }

        private async void GetDocument()
        {
            var Document = DownloadHtml("https://www.supremenewyork.com/shop/jackets/f9d7nzc4j/ffh6c2zoj");
            
            var d = await SendAddToBasketRequestAsync();

            int f = 0;
        }

        public void AddToBasket()
        {
            //string Source = DownloadHtml(Item.UrlAddress);
            var d = Item.UrlAddress;
            var Items = new ObservableCollection<ArtList>();

            string Source = DownloadHtml("https://www.supremenewyork.com/shop/jackets/f9d7nzc4j/ffh6c2zoj");
            //IConfiguration config = Configuration.Default.WithDefaultLoader();
            IConfiguration config = Configuration.Default.WithDefaultLoader();
            //var config = Configuration.Default.WithJavaScript();
            IBrowsingContext context = BrowsingContext.New(config);
            HtmlParser Parser = new HtmlParser();
            IHtmlDocument Document = Parser.ParseDocument(Source);
            //var AddToBasketButton = "input[name=\"commit\"] > article > div[class = \"inner-article\"] > a[href]";
            //var AddToBasketButton = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > div[id=\"cctrl\"] > input[name=\"commit\"]";
            //string AddToBasketSelector = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > div[id=\"cctrl\"] > form[id=\"cart-addf\"] > fieldset[id=\"add-remove-buttons\"]";
            string AddToBasketSelector = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > div[id=\"cctrl\"] > form[id=\"cart-addf\"] > fieldset > input";
            var ImgTag = "IMG";
            IHtmlFormElement AddToBasketButton = Document.QuerySelector(AddToBasketSelector) as IHtmlFormElement;
            IHtmlInputElement dd = Document.QuerySelector(AddToBasketSelector) as IHtmlInputElement;
            dd.SubmitAsync();
            dd.DoClick();
            //AddToBasketButton.DoClick();
            //var sdfsdfsdf = Document.QuerySelector<IHtmlFormElement>("form#login");
            //var dd = context.Active.    QuerySelector<IHtmlFormElement>("dsf");
            Source = DownloadHtml("https://www.supremenewyork.com/shop/jackets/f9d7nzc4j/ffh6c2zoj");
            Document = Parser.ParseDocument(Source);
            
            string check = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > div[id=\"cctrl\"] > form[id=\"cart-remove\"]";
            var ss = Document.QuerySelector(check);
            //{
            //    User = "User",
            //    Password = "secret"
            //});
            //var sdfsdfsdf = context.Active.QuerySelector<IHtmlFormElement>(AddToBasketSelector).;

            var ItemsCount = AddToBasketButton.Length;


            //foreach (var art in AllArtsList)
            //{
            //    var ImageElement = art.GetElementsByTagName(ImgTag);
            //    var SoldOutTag = art.GetElementsByClassName("sold_out_tag").Length == 0 ? false : true;
            //    var ImageReference = ImageElement[0].GetAttribute("src");

            //    Items.Add(new ArtList { Reference = art.GetAttribute("href"), Image = "https:" + ImageReference, SoldOut = SoldOutTag, SoldOutVisibility = Visibility.Hidden });
            //}

            //ArtsList = Items;
            var i = 0;
        }

        #endregion Method
    }
}
