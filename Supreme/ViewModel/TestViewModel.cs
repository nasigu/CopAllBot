using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Supreme.Core;
using Supreme.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Supreme.Core.KeywordSearchEngine;
using Supreme.Model.Supreme;

namespace Supreme.ViewModel
{
    public class TestViewModel : BaseItemViewModel<Test>
    {
        #region Constructor

        public TestViewModel(Test item) : base(item)
        {
        }

        public TestViewModel() : base(new Test())
        {
            config = Configuration.Default.WithDefaultLoader();
            context = BrowsingContext.New(config);
            Parser = new HtmlParser();
        }

        #endregion Constructor

        #region Property

        IConfiguration config;
        IBrowsingContext context;
        HtmlParser Parser;

        public ObservableCollection<Test> Test { get; set; }
        public ObservableCollection<string> Output { get; set; }

        public string labelText
        {
            get; set;
        }

        string billing_name = "Super Svin";
        string email = "nkatrvld@gmail.com";
        string tel = "+79347834736";
        string billing_address = "Pushkina 8";
        string billing_address_2 = "";
        string billing_address_3 = "";
        string billing_city = "Moscow";
        string billing_zip = "119603";
        string billing_country = "RU";
        string same_as_billing_address = "1";
        string store_credit_id = "";
        string type = "master";
        string cnb = "5321 3045 7241 2143";
        string month = "11";
        string year = "2023";
        string vval = "159";
        string termsFirtst = "0";
        string termsSecond = "1";
        string g_recaptcha_response = "03AOLTBLRdNpSCMIPMyrDATG8hPSDX0Boq9w4z06XXwUOhAxp_5_IUuz9ceo-aRiARVQqNxj0s0T023-nhEGd3oGh3Mc9vc-W0-2YUKmTQqNHZyuce5oW9iV595u3gFmzUyG880yXA9x8r6CLsXzbbsPhA-VvmHl2JONcZoRqoozCcuiaUMCt40x_r4Ngf-8dH2Cg56zPhxia_fDZNaMmmsrZGWF8i0lMJx6slhIQpoYgR0Oy8rGZzEeTM9Npb3EdpUDpdPV9Rpxy3-8vShV1uLAcrhQoIJGEBezHHH3pL0ECX4ab8cJNmGTDG6oY1NepzFKpMoyZIUWDj";
        string hpcvv = "";

        HttpClient client = new HttpClient();
        #endregion Property


        #region Command

        private ICommand _AddToBasketCommand;
        public ICommand AddToBasketCommand { get { return _AddToBasketCommand ?? (_AddToBasketCommand = new ActCommand(GetDocument)); } }

        private ICommand _GetSizesCommand;
        public ICommand GetSizesCommand { get { return _GetSizesCommand ?? (_GetSizesCommand = new ActCommand(MobileTesting)); } }

        private ICommand _MobileTestingCommand;
        public ICommand MobileTestingCommand { get { return _MobileTestingCommand ?? (_MobileTestingCommand = new ActCommand(MobileTesting)); } }

        private ICommand _DesktopTestingCommand;
        public ICommand DesktopTestingCommand { get { return _DesktopTestingCommand ?? (_DesktopTestingCommand = new ActCommand(DesktopTest)); } }

        private ICommand _MobileStockCommand;
        public ICommand MobileStockCommand { get { return _MobileStockCommand ?? (_MobileStockCommand = new ActCommand(MobileStockTest)); } }


        #endregion Command

        #region Method

        async Task<string> SendAddToBasketRequestAsync()
        {
            var task = new Model.Task()
            {
                Color = "Purple",
                ProductSize = Enums.Size.Medium
            };

            string Source = DownloadHtml("https://www.supremenewyork.com/shop/304279");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            var dict = new Dictionary<string, string>();
            string url = "https://www.supremenewyork.com/shop/304260/add";
            dict.Add("utf8", "%E2%9C%93");
            dict.Add("style", GetStyle(Document, task)); ;
            dict.Add("size", GetSize(Document, task));
            dict.Add("commit", "add to basket");
            var CSRFToken = GetCSRFToken(Document);
            var cartCookie = GetCartCookie(Document, task);
            var pureCartCookie = GetPureCartCookie(Document, task);
            var mixpanelCookie = GetMixpanelCookie(Document, task);
            var mixpanelCookieName = GetMixpanelCookieName(Document);

            client.DefaultRequestHeaders.Add("Accept", "*/*;q=0.5, text/javascript, application/javascript, application/ecmascript, application/x-ecmascript");
            client.DefaultRequestHeaders.Add("x-csrf-token", CSRFToken);
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.DefaultRequestHeaders.Add("Cookie", $"cart={cartCookie};path=//; request_method=POST;path=// pure_cart={pureCartCookie};path=//");
            HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(dict));
            return response.Content.ReadAsStringAsync().Result;
        }

        async Task<string> SendAddToBasketMobileRequestAsync()
        {
            var task = new Model.Task()
            {
                Color = "Orange",
                ProductSize = Enums.Size.Medium
            };

            string Source = DownloadHtml("https://www.supremenewyork.com/shop/sweatshirts/pma47nqb1/pu4k2tbd6");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            var dict = new Dictionary<string, string>();
            string url = "https://www.supremenewyork.com/shop/304260/add.json";
            dict.Add("style", GetStyle(Document, task)); ;
            dict.Add("size", GetSize(Document, task));
            dict.Add("qty", "1");
            var CSRFToken = GetCSRFToken(Document);
            var cartCookie = GetCartCookie(Document, task);
            var pureCartCookie = GetPureCartCookie(Document, task);
            var mixpanelCookie = GetMixpanelCookie(Document, task);
            var mixpanelCookieName = GetMixpanelCookieName(Document);

            client.DefaultRequestHeaders.Add("Accept", "*/*;q=0.5, text/javascript, application/javascript, application/ecmascript, application/x-ecmascript");
            client.DefaultRequestHeaders.Add("x-csrf-token", CSRFToken);
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.DefaultRequestHeaders.Add("Cookie", $"cart={cartCookie};path=//; request_method=POST;path=// pure_cart={pureCartCookie};path=//");
            HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(dict));
            return response.Content.ReadAsStringAsync().Result;
        }



        async Task<string> ToShopCartRequestAsync()
        {
            var task = new Model.Task()
            {
                Color = "Purple",
                ProductSize = Enums.Size.Medium
            };

            string Source = DownloadHtml("https://www.supremenewyork.com/shop/cart");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            string url = "https://www.supremenewyork.com/shop/cart";
            var CSRFToken = GetCSRFToken(Document);
            client.DefaultRequestHeaders.Add("Accept", "text/html, application/xhtml+xml, application/xml");
            HttpResponseMessage response = await client.GetAsync(url);
            return response.Content.ReadAsStringAsync().Result;
        }

        async Task<string> ToCheckoutRequestAsync()
        {
            var task = new Model.Task()
            {
                Color = "Purple",
                ProductSize = Enums.Size.Medium
            };

            string Source = DownloadHtml("https://www.supremenewyork.com/mobile/#checkout");
            IHtmlDocument Document = Parser.ParseDocument(Source);

            string url = "https://www.supremenewyork.com/mobile/#checkout";

            var CSRFToken = GetCSRFToken(Document);
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            HttpResponseMessage response = await client.GetAsync(url);
            return response.Content.ReadAsStringAsync().Result;
        }

        async Task<string> SendAddToPaymentsRequestAsync()
        {
            var task = new Model.Task()
            {
                Color = "Purple",
                ProductSize = Enums.Size.Medium
            };

            string Source = DownloadHtml("https://www.supremenewyork.com/checkout");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            var CSRFToken = GetCSRFToken(Document);

            var billing_name = "Super Svin";
            var email = "nkatrvld@gmail.com";
            var tel = "+79347834736";
            var billing_address = "Pushkina 8";
            var billing_address_2 = "";
            var billing_address_3 = "";
            var billing_city = "Moscow";
            var billing_zip = "119603";
            var billing_country = "RU";
            var same_as_billing_address = "1";
            var store_credit_id = "";
            var type = "master";
            var cnb = "5321 3045 7241 2143";
            var month = "11";
            var year = "2023";
            var vval = "159";
            var termsFirtst = "0";
            var termsSecond = "1";
            var g_recaptcha_response = "03AOLTBLRM7DjB7wZ1vKfUNCwcmjtTlK4GZqA8IFQEd0hYqThWmgKHNwWhZ82WsV8R73tA5s5GwUycpjrT39kg1Lh9E4XOSKUIXpFRu7ueWv7rJwXM6Bqr9BKW2AeQuBgk1wypJmiH6QJxJIA1yX3gZdsVCTOT5RNiOQPbzJX9RJN10kttjKS_A7HtPs56Qie8OYSBRq-kRiTAwc_1IyuEzcy2CtfLWuyUd3qfndOQGCAAPuWRdnwbWWLTNTMsp6RDpV6fzYXduX3CWdQSIAf93UAf7ez3_Qr_m5E_uekr9FtM_H97LrQAqN37vD5nrlix4znnyQWeOdOL";
            var hpcvv = "";

            string url = "https://www.supremenewyork.com/checkout.json";

            FormUrlEncodedContent content = new FormUrlEncodedContent(new[] {
  new KeyValuePair < string, string > ("utf8", "%E2%9C%93"),
    new KeyValuePair < string, string > ("authenticity_token", CSRFToken),
    new KeyValuePair < string, string > ("order[billing_name]", billing_name),
    new KeyValuePair < string, string > ("order[email]", email),
    new KeyValuePair < string, string > ("order[tel]", tel),
    new KeyValuePair < string, string > ("order[billing_address]", billing_address),
    new KeyValuePair < string, string > ("order[billing_address_2]", billing_address_2),
    new KeyValuePair < string, string > ("order[billing_address_3]", billing_address_3),
    new KeyValuePair < string, string > ("order[billing_city]", billing_city),
    new KeyValuePair < string, string > ("order[billing_zip]", billing_zip),
    new KeyValuePair < string, string > ("order[billing_country]", billing_country),
    new KeyValuePair < string, string > ("same_as_billing_address", same_as_billing_address),
    new KeyValuePair < string, string > ("store_credit_id[]", store_credit_id),
    new KeyValuePair < string, string > ("credit_card[type]", type),
    new KeyValuePair < string, string > ("credit_card[cnb]", cnb),
    new KeyValuePair < string, string > ("credit_card[month]", month),
    new KeyValuePair < string, string > ("credit_card[year]", year),
    new KeyValuePair < string, string > ("credit_card[vval]", vval),
    new KeyValuePair < string, string > ("order[terms][]", termsFirtst),
    new KeyValuePair < string, string > ("order[terms][]", termsSecond),
    new KeyValuePair < string, string > ("g-recaptcha-response", g_recaptcha_response),
    new KeyValuePair < string, string > ("hpcvv", hpcvv),

});

            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("x-csrf-token", CSRFToken);
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            //HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(dict));
            HttpResponseMessage response = await client.PostAsync(url, content);
            return response.Content.ReadAsStringAsync().Result;
        }



        async Task<string> SendAddToPaymentsMobileRequestAsync()
        {
            var task = new Model.Task()
            {
                Color = "Purple",
                ProductSize = Enums.Size.Medium
            };
            // string EncodedResponse = Request.Form["g-Recaptcha-Response"];

            string Source = DownloadHtml("https://www.supremenewyork.com/mobile/#checkout");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            var CSRFToken = GetCSRFToken(Document);

            var billing_name = "Super Svin";
            var email = "nkatrvld@gmail.com";
            var tel = "+79347834736";
            var billing_address = "Pushkina 8";
            var billing_address_2 = "";
            var billing_address_3 = "";
            var billing_city = "Moscow";
            var billing_zip = "119603";
            var billing_country = "RU";
            var same_as_billing_address = "1";
            var store_credit_id = "";
            var type = "master";
            var cnb = "5321 3045 7241 2143";
            var month = "11";
            var year = "2023";
            var vval = "159";
            var termsFirtst = "0";
            var termsSecond = "1";
            var g_recaptcha_response = "03AOLTBLRdNpSCMIPMyrDATG8hPSDX0Boq9w4z06XXwUOhAxp_5_IUuz9ceo-aRiARVQqNxj0s0T023-nhEGd3oGh3Mc9vc-W0-2YUKmTQqNHZyuce5oW9iV595u3gFmzUyG880yXA9x8r6CLsXzbbsPhA-VvmHl2JONcZoRqoozCcuiaUMCt40x_r4Ngf-8dH2Cg56zPhxia_fDZNaMmmsrZGWF8i0lMJx6slhIQpoYgR0Oy8rGZzEeTM9Npb3EdpUDpdPV9Rpxy3-8vShV1uLAcrhQoIJGEBezHHH3pL0ECX4ab8cJNmGTDG6oY1NepzFKpMoyZIUWDj";
            var hpcvv = "";

            string url = "https://www.supremenewyork.com/checkout.json";
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[] {
                new KeyValuePair < string, string > ("store_credit_id", store_credit_id),
                new KeyValuePair < string, string > ("from_mobile", "1"),
                new KeyValuePair < string, string > ("cookie-sub: ", "{{\"55920\":1}}"),
                new KeyValuePair < string, string > ("same_as_billing_address", same_as_billing_address),
                new KeyValuePair < string, string > ("authenticity_token", CSRFToken),
                new KeyValuePair < string, string > ("order[billing_name]", billing_name),
                new KeyValuePair < string, string > ("order[email]", email),
                new KeyValuePair < string, string > ("order[tel]", tel),
                new KeyValuePair < string, string > ("order[billing_address]", billing_address),
                new KeyValuePair < string, string > ("order[billing_address_2]", billing_address_2),
                new KeyValuePair < string, string > ("order[billing_address_3]", billing_address_3),
                new KeyValuePair < string, string > ("order[billing_city]", billing_city),
                new KeyValuePair < string, string > ("order[billing_zip]", billing_zip),
                new KeyValuePair < string, string > ("order[billing_country]", billing_country),
                new KeyValuePair < string, string > ("credit_card[type]", type),
                new KeyValuePair < string, string > ("credit_card[cnb]", cnb),
                new KeyValuePair < string, string > ("credit_card[month]", month),
                new KeyValuePair < string, string > ("credit_card[year]", year),
                new KeyValuePair < string, string > ("credit_card[vval]", vval),
                //new KeyValuePair < string, string > ("order[terms][]", termsFirtst),
                new KeyValuePair < string, string > ("order[terms][]", termsSecond),
                new KeyValuePair < string, string > ("g-recaptcha-response", g_recaptcha_response),

            });
            //System.Net.Http.FormUrlEncodedContent vd = new FormUrlEncodedContent();
            //accept-encoding: gzip, deflate, br
            client.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("x-csrf-token", CSRFToken);
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            HttpResponseMessage response = await client.PostAsync(url, content);

            return response.Content.ReadAsStringAsync().Result;
        }

        void MobileStockTest()
        {
            var i = GetMobileStockRequestAsync();
            var dfd = 0;
        }

        MobileStock GetMobileStockRequestAsync()
        {
            var task = new Model.Task()
            {
                Color = "White",
                ProductSize = Enums.Size.Medium,
                //ProductName = "Putti Tee",
                ProductName = "Overdyed Pocket, Tee",
                ProductCategory = "Tops/Sweaters"

            };


            string MobileStockJsonString = DownloadHtml("https://www.supremenewyork.com/mobile_stock.json");

            MobileStock data = MobileStock.FromJson(MobileStockJsonString);
            string IdOfProduct = GetIdByTask(data, task);


            Product productData;

            if (IdOfProduct != "")
            {
                string ProductJson = DownloadHtml($"https://www.supremenewyork.com/shop/{IdOfProduct}.json");
                productData = Product.FromJson(ProductJson);
            }
            else
            {
                // TODO: Log system
                throw new NotImplementedException();
            }

            string ColorId = "";
            string SizeId = "";
            GetColorIDByTask(productData, task, out ColorId, out SizeId);
            var i = 0;

            return data;

        }

        private void GetColorIDByTask(Product data, Model.Task task, out string ColorId, out string SizeId)
        {
            IKeyWordEngine searchEngine = new AhoCorasick();
            ColorId = "";
            SizeId = "";
            foreach (var item in data.Styles)
            {
                if (searchEngine.Search(item.Name, new List<string>() { task.Color.Trim().ToLower() }))
                {
                    ColorId = item.Id.ToString();


                    foreach (var size in item.Sizes)
                    {
                        if (searchEngine.Search(size.Name.ToString(), new List<string>() { task.ProductSize.ToString().Trim().ToLower() }))
                        {
                            SizeId = size.Id.ToString();
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private string GetSizeIDByTask(Product data, Model.Task task)
        {
            IKeyWordEngine searchEngine = new AhoCorasick();

            foreach (var item in data.Styles)
            {
                if (searchEngine.Search(item.Name, new List<string>() { task.Color }))
                {
                    return item.Id.ToString();
                }
            }
            return "";
        }

        private string GetIdByTask(MobileStock data, Model.Task task)
        {
            IKeyWordEngine searchEngine = new AhoCorasick();

            var keywords = new List<string>();
            foreach (var item in task.ProductName.Split(','))
            {
                keywords.Add(item.Trim().ToLower());
            }

            if (data.ProductsAndCategories.ContainsKey(task.ProductCategory))
            {
                foreach (var item in data.ProductsAndCategories[task.ProductCategory])
                {
                    if (searchEngine.Search(item.Name, keywords))
                    {
                        return item.Id.ToString();
                    }
                }
            }

            if (data.ProductsAndCategories.ContainsKey("new"))
            {
                foreach (var item in data.ProductsAndCategories["new"])
                {
                    if (searchEngine.Search(item.Name, keywords))
                    {
                        return item.Id.ToString();
                    }
                }
            }

            return "";
        }



        private string cookie(IHtmlDocument Document)
        {
            var task = new Model.Task()
            {
                Color = "Purple",
                ProductSize = Enums.Size.Medium
            };

            var cartCookie = GetCartCookie(Document, task);
            var pureCartCookie = GetPureCartCookie(Document, task);
            var mixpanelCookie = GetMixpanelCookie(Document, task);
            var mixpanelCookieName = GetMixpanelCookieName(Document);
            var expires = "; expires=Fri, 3 Aug 2020 20:47:11 UTC; path=/;";
            var df = $"document.cookie = \"cart={cartCookie}{expires}pure_cart={pureCartCookie}{expires}{mixpanelCookieName}={mixpanelCookie}{expires}\"";
            return $"cart={cartCookie}{expires}pure_cart={pureCartCookie}{expires}{mixpanelCookieName}={mixpanelCookie}{expires}";
        }

        private async Task<string> PostRequestAsync()
        {
            string Source = DownloadHtml("https://www.supremenewyork.com/mobile/#checkout");
            string Sourcecookie = DownloadHtml("https://www.supremenewyork.com/shop/sweatshirts/pma47nqb1/pu4k2tbd6");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            IHtmlDocument Documentcookie = Parser.ParseDocument(Sourcecookie);
            var CSRFToken = GetCSRFToken(Document);

            WebRequest request = (HttpWebRequest)WebRequest.Create("https://www.supremenewyork.com/checkout.json");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = $"store_credit_id = {store_credit_id}, from_mobile = 1, cookie-sub = {{\"55920\":1}}, same_as_billing_address = {same_as_billing_address}, authenticity_token = {CSRFToken}, "
                + $"order[billing_name] = {billing_name}, order[email] = {email}, order[tel] = {tel}, order[billing_address] = {billing_address}, order[billing_address_2] = {billing_address_2}, "
                + $"order[billing_address_3] = {billing_address_3}, order[billing_city] = {billing_city}, order[billing_zip] = {billing_zip}, order[billing_country] = {billing_country}, "
                + $"credit_card[type] = {type}, credit_card[cnb] = {cnb}, credit_card[month] = {month}, credit_card[year] = {year}, credit_card[vval] = {vval}, "
                + $"order[terms] = 0, order[terms] = 1, g-recaptcha-response = {g_recaptcha_response}";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;
            request.Headers.Add("x-csrf-token", CSRFToken);
            var ssss = cookie(Documentcookie);
            request.Headers.Add("Cookie", ssss);
            //request.Headers.Add("Accept", "*/*");

            //request.Headers.Add("Accept", "*/*");


            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            string resp = "";
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    resp = reader.ReadToEnd();
                    Console.WriteLine("Response: " + resp);
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен...");
            return resp;

        }



        private string GetMixpanelCookieName(IHtmlDocument document)
        {
            var token = GetMixpanelToken(document);
            return $"mp_{token}_mixpanel";
        }

        private string GetMixpanelCookie(IHtmlDocument document, Model.Task task)
        {
            var distinct_id = GetDistinctId();
            return $"{{\"distinct_id\": \"{distinct_id}\",\"$device_id\": \"{distinct_id}\",\"Store Location\": \"EU Web\",\"Platform\": \"Web\",\"$initial_referrer\": \"$direct\",\"$initial_referring_domain\": \"$direct\"}}";
        }


        private string GetPureCartCookie(IHtmlDocument document, Model.Task task)
        {
            var size = GetSize(document, task);
            var style = GetStyle(document, task);
            var price = GetInnerContentBySelector(document, productCostAndCurrencySelector);
            return $"{{{size}:1,cookie:1 item--{size},{style},total:{price}";
        }

        private string GetCartCookie(IHtmlDocument document, Model.Task task)
        {
            return "1 item" + "--" + GetSize(document, task) + "," + GetStyle(document, task);
        }

        private string GetSize(IHtmlDocument document, Model.Task task)
        {
            string selector = sizeSelector;
            var sizes = GetElementsBySelector(document, selector);
            foreach (var size in sizes)
            {
                if (size.InnerHtml == task.ProductSize.ToString())
                {
                    return size.GetAttribute("value");
                }
            }
            return "";
        }

        private string GetStyle(IHtmlDocument document, Model.Task task)
        {
            string selector = styleStrSelector;
            string intSelector = styleIntSelector;
            var styles = GetElementsBySelector(document, selector);
            foreach (var style in styles)
            {
                if (style.InnerHtml.Trim() == task.Color)
                {
                    var styleInt = GetElementBySelector(document, intSelector);
                    return styleInt.GetAttribute("value");
                }
            }
            return "";
        }

        private string GetCSRFToken(IHtmlDocument document)
        {
            string selector = CSRFTokenSelector;
            var items = GetElementsBySelector(document, selector);
            foreach (var item in items)
            {

                if (item.GetAttribute("name") == "csrf-token")
                {
                    return item.GetAttribute("content");
                }
            }

            return "Logs need you s-s..senpai";
        }

        private async void GetDocument()
        {

        }

        //ADD METHOD SELECTORS
        private string CSRFTokenSelector = "head > meta";
        private string sizeSelector = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > div[id=\"cctrl\"] > form[id=\"cart-addf\"] > fieldset > select > option";
        private string styleStrSelector = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > p[class=\"style protect\"]";
        private string styleIntSelector = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > div[id=\"cctrl\"] > form[id=\"cart-addf\"] > input[id=\"style\"]";

        //MIXPANEL SELECTORS
        private string productNameByAltImageSelector = "div[id=\"wrap\"] > div[id=\"container\"] > article > figure > img[alt]";
        private string productNameByH1Selector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > h1[class=\"protect\"]";
        private string productColorSelector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > p";
        private string productCostAndCurrencySelector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > p[class=\"price\"] > span";
        private string categoryNameSelector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > h1";
        private string soldOutSelector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > div[id=\"cctrl\"] > form > fieldset[id=\"add-remove-buttons\"] > b[class=\"button sold-out\"]";
        private string productNumberSelector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > h1";
        private string releaseWeekSelector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > h1";
        private string releaseDateSelector = "div[id=\"wrap\"] > div[id=\"container\"] > div[id=\"details\"] > h1";
        private string scriptSelector = "head > script";

        private async void MobileTesting()
        {
            string Source = DownloadHtml("https://www.supremenewyork.com/shop/sweatshirts/pma47nqb1/pu4k2tbd6");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            var lskjdf = await SendAddToBasketMobileRequestAsync();
            var mobileCheckout = await SendAddToPaymentsMobileRequestAsync();
            var iuuuui = LoadArtList();
            var webreq = await PostRequestAsync();
            var i = 0;
        }

        private async void DesktopTest()
        {
            string Source = DownloadHtml("https://www.supremenewyork.com/shop/sweatshirts/pma47nqb1/pu4k2tbd6");
            IHtmlDocument Document = Parser.ParseDocument(Source);
            var lskjdf = await SendAddToBasketMobileRequestAsync();
            var df = await SendAddToBasketRequestAsync();
            var lsd = await ToShopCartRequestAsync();
            var ij = await ToCheckoutRequestAsync();
            var dewwewe = await SendAddToPaymentsRequestAsync();
            var i = 0;
        }

        private static readonly string Extension = "https";
        private static readonly string Site = "www.supremenewyork.com";
        private static readonly string ShopAllAddress = $"{Extension}://{Site}/shop/all";

        public List<string> LoadArtList()
        {

            string Source = DownloadHtml(ShopAllAddress);
            //var Items = new ObservableCollection<ArtList>();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var Parser = new HtmlParser();
            var Document = Parser.ParseDocument(Source);
            var ListSelector = "div[id=\"container\"] > article > div[class = \"inner-article\"] > a[href]";
            var ImgTag = "IMG";
            var AllArtsList = Document.QuerySelectorAll(ListSelector);
            var ItemsCount = AllArtsList.Length;

            var ddd = new List<string>();

            foreach (var art in AllArtsList)
            {
                //var ImageElement = art.GetElementsByTagName(ImgTag);
                //var SoldOutTag = art.GetElementsByClassName("sold_out_tag").Length == 0 ? false : true;
                //var ImageReference = ImageElement[0].GetAttribute("src");

                ddd.Add(art.GetAttribute("href"));
            }

            return ddd;

            // ArtsList = Items;
        }

        string GetMixpanelData()
        {
            string Source = DownloadHtml("https://www.supremenewyork.com/shop/sweatshirts/pma47nqb1/pu4k2tbd6");
            IHtmlDocument Document = Parser.ParseDocument(Source);

            const string eventStr = "\"event\": \"Add to Cart Attempt\"";
            const string osStr = "\"$os\": \"Windows\"";
            const string browserStr = "\"$browser\": \"Opera\"";
            string currentUrlStr = "\"$current_url\": \"https://www.supremenewyork.com/shop/sweatshirts/pma47nqb1/pu4k2tbd6" + "\"";
            const string browserVersionStr = "\"$browser_version\": 58";
            const string screenHeightStr = "\"$screen_height\": 1080";
            const string screenWidthStr = "\"$screen_width\": 1920";
            const string mpLibStr = "\"mp_lib\": \"web\"";
            const string libVersionStr = "\"$lib_version\": \"2.28.0\"";
            string timeStr = "\"time\": " + GetTimestampString();
            string distinctIdStr = "\"distinct_id\": \"" + GetDistinctId() + "\"";
            string deviceIdStr = "\"$device_id\": \"" + GetDistinctId() + "\"";
            const string storeLocationStr = "\"Store Location\": \"EU Web\"";
            const string platformStr = "\"Platform\": \"Web\"";
            const string initialReferrerStr = "\"$initial_referrer\": \"$direct\"";
            const string initialReferringDomainStr = "\"$initial_referring_domain\": \"$direct\"";
            const string urlStr = "\"URL\": \"/shop/sweatshirts/pma47nqb1/pu4k2tbd6\"";
            string pageNameStr = "\"Page Name\": \"" + GetInnerContentBySelector(Document, productNameByH1Selector) + "- " + GetInnerContentBySelector(Document, productColorSelector).Trim() + "\"";
            const string seasonStr = "\"Season\": \"FW17\"";
            const string deviceTypeStr = "\"Device Type\": \"Desktop\"";
            const string eventNameStr = "\"Event Name\": \"Add to Cart Attempt\"";
            const string siteRegionStr = "\"Site Region\": \"EU\"";
            string productColorStr = "\"Product Color\": \"" + GetInnerContentBySelector(Document, productColorSelector) + "\"";
            string productCostStr = "\"Product Cost\": \"" + GetInnerContentBySelector(Document, productCostAndCurrencySelector).Replace("€", "") + "\"";
            string currencyStr = "\"Currency\": \"" + (GetInnerContentBySelector(Document, productCostAndCurrencySelector).Contains("€") ? "EUR" : "$") + "\"";
            string productNameStr = "\"Product Name\": \"" + GetInnerContentBySelector(Document, productNameByH1Selector) + "\"";
            string categoryNameStr = "\"Category\": \"" + GetElementBySelector(Document, categoryNameSelector).GetAttribute("data-category") + "\"";
            string soldOutStr = "\"Sold Out?\": " + (GetElementBySelector(Document, soldOutSelector) == null ? "false" : "true").ToString();
            string productNumberStr = "\"Product Number\": \"" + GetAtributeBySelector(Document, productNumberSelector, "data-ino") + "\"";
            string releaseWeekStr = "\"Release Week\": \"" + GetAtributeBySelector(Document, releaseWeekSelector, "data-rw") + "\"";
            string releaseDateStr = "\"Release Date\": \"" + GetAtributeBySelector(Document, releaseDateSelector, "data-rd") + "\"";
            string productSizeStr = "\"Product Size\": \"Medium\"";
            string tokenStr = "\"token\": \"" + GetMixpanelToken(Document) + "\"";

            //var a = $"{{{eventStr},\"properties\": {{{osStr},{browserStr},{currentUrlStr},{browserVersionStr},{screenHeightStr},{screenWidthStr},{mpLibStr},{libVersionStr},{timeStr},{distinctIdStr},{deviceIdStr},{storeLocationStr},{platformStr},{initialReferrerStr},{initialReferringDomainStr},{urlStr},{pageNameStr},{seasonStr},{deviceTypeStr},{eventNameStr},{siteRegionStr},{productColorStr},{productCostStr},{currencyStr},{productNameStr},{categoryNameStr},{soldOutStr},{productNumberStr},{releaseWeekStr},{releaseDateStr},{productSizeStr},{tokenStr}}}}}";
            //var a = $"{{{eventStr},\"properties\": {{{osStr},{browserStr},{currentUrlStr},{browserVersionStr}," + 
            //        $"{screenHeightStr},{screenWidthStr},{mpLibStr},{libVersionStr},{timeStr},{distinctIdStr}," + 
            //        $"{deviceIdStr},{storeLocationStr},{platformStr},{initialReferrerStr},{initialReferringDomainStr}," + 
            //        $"{urlStr},{pageNameStr},{seasonStr},{deviceTypeStr},{eventNameStr},{siteRegionStr},{productColorStr}," + 
            //        $"{productCostStr},{currencyStr},{productNameStr},{categoryNameStr},{soldOutStr},{productNumberStr}," + 
            //        $"{releaseWeekStr},{releaseDateStr},{productSizeStr},{tokenStr}}}}}";
            return $"{{{eventStr},\"properties\": {{{osStr},{browserStr},{currentUrlStr},{browserVersionStr}," +
                    $"{screenHeightStr},{screenWidthStr},{mpLibStr},{libVersionStr},{timeStr},{distinctIdStr}," +
                    $"{deviceIdStr},{storeLocationStr},{platformStr},{initialReferrerStr},{initialReferringDomainStr}," +
                    $"{urlStr},{pageNameStr},{seasonStr},{deviceTypeStr},{eventNameStr},{siteRegionStr},{productColorStr}," +
                    $"{productCostStr},{currencyStr},{productNameStr},{categoryNameStr},{soldOutStr},{productNumberStr}," +
                    $"{releaseWeekStr},{releaseDateStr},{productSizeStr},{tokenStr}}}}}"; ;
        }




        string GetAddData(string data)
        {
            string Source = DownloadHtml("https://www.supremenewyork.com/shop/sweatshirts/pma47nqb1/pu4k2tbd6");
            IHtmlDocument Document = Parser.ParseDocument(Source);

            int b = 0, d = 0, e = 0, g = 0, j = 0, m = 0;
            var a = data;
            string[] i = new string[a.Length];
            do
            {
                if (j + 1 <= a.Length)
                    b = (int)a[j++];
                if (j + 1 <= a.Length)
                    d = (int)a[j++];
                if (j + 1 <= a.Length)
                    e = (int)a[j++];
                g = b << 16 | d << 8 | e;
                b = g >> 18 & 63;
                d = g >> 12 & 63;
                e = g >> 6 & 63;
                g &= 63;
                i[m] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="[b].ToString() +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="[d].ToString() +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="[e].ToString() +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/="[g].ToString();
                m++;


            } while (j < a.Length);
            var result = string.Join("", i);

            switch (a.Length % 3)
            {
                case 1:
                    result = result.Substring(0, result.Length - 2) + "==";
                    break;
                case 2:
                    result = result.Substring(0, result.Length - 1) + "=";
                    break;
            }
            return result;

        }

        private string GetAddReference()
        {
            var data = GetAddData(GetMixpanelData());
            string mixpanelApi = "https://api.mixpanel.com/track/?data=";
            var fdf = mixpanelApi + data + "&ip=1&_=" + GetTimestampStringWithoutComma();
            return mixpanelApi + data + "&ip=1&_=" + GetTimestampStringWithoutComma();
        }

        //private void GetSize()
        //{
        //    var Items = new ObservableCollection<string>();
        //    string Source = DownloadHtml("https://www.supremenewyork.com/shop/pants/k0od6gy1a/thb4lxy5c");
        //    IHtmlDocument Document = Parser.ParseDocument(Source);
        //    string SizeSelector = "div[id=\"wrap\"] > div[id=\"container\"]  > div[id=\"details\"] > div[id=\"cctrl\"] > form[id=\"cart-addf\"] > fieldset > select > option";
        //    var Sizes = Document.QuerySelectorAll(SizeSelector);

        //    foreach (var art in Sizes)
        //    {
        //        var ImageElement = art.GetAttribute("value");
        //        Items.Add(ImageElement);
        //    }
        //}


        private string GetTimestampString()
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;
            TimeSpan elapsedTime = utcNow - unixEpoch;
            double millis = elapsedTime.TotalMilliseconds;
            return (millis / 1000).ToString("#.##").Replace(",", ".");
        }

        private string GetTimestampStringWithoutComma()
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;
            TimeSpan elapsedTime = utcNow - unixEpoch;
            double millis = elapsedTime.TotalMilliseconds;
            return (millis / 100).ToString("#.##").Replace(",", "");
        }

        string GetDistinctId()
        {
            return GetTimeStampHex() + "-" + GetRandomDoubleStr() + "-" + ShiftElements() + "-" + GetHeightWidth(1080, 1920) + "-" + GetTimeStampHex();
        }

        string ShiftElements()
        {
            var z = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36 OPR/58.0.3135.132";

            List<int> j = new List<int>();
            var b = 0;
            var c = 0;
            var m = 0;
            for (b = 0; b < z.Length; b++)
            {
                c = (int)z[b];
                j.Insert(0, c & 255);

                if (4 <= j.Count)
                {
                    m = s(m, j);
                    j.Clear();
                }
            }
            if (0 < j.Count)
            {
                m = s(m, j);
            }

            return m.ToString("x");

            int s(int f, List<int> g)
            {
                var e = 0;
                for (c = 0; c < g.Count; c++)
                    e |= j[c] << 8 * c;
                return f ^ e;
            }

        }

        string GetRandomDoubleStr()
        {
            Random rand = new Random();
            var randDouble = rand.NextDouble();
            var decimalNumber = randDouble.ToString();
            var arrayStrNumber = decimalNumber.Split(',');
            var strNumber = arrayStrNumber[1];
            var strNumberToInt = Convert.ToInt64(strNumber);
            var test = "0" + strNumberToInt.ToString("x");
            return "0" + strNumberToInt.ToString("x");

        }

        string GetHeightWidth(int height, int width)
        {
            return (height * width).ToString("x");
        }

        private string GetTimeStampHex()
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;
            TimeSpan elapsedTime = utcNow - unixEpoch;
            double millis = elapsedTime.TotalMilliseconds;
            long time = Convert.ToInt64(millis);
            Random rand = new Random();
            var b = rand.Next(0, 3000);
            return time.ToString("x") + b.ToString("x");
        }

        private string GetMixpanelToken(IHtmlDocument document)
        {
            string token = "";
            foreach (var script in document.Scripts)
            {
                if (script.InnerHtml.Contains("mixpanel.init"))
                {
                    var tokenStartStr = "mixpanel.init(\"";
                    var tokenEndStr = "mixpanel.register";

                    var tokenStartIndex = script.InnerHtml.IndexOf(tokenStartStr);
                    var tokenEndIndex = script.InnerHtml.IndexOf(tokenEndStr);

                    var tokenLenght = tokenEndIndex - tokenStartIndex;

                    var tokenSubString = script.InnerHtml.Substring(tokenStartIndex, tokenLenght);
                    string tokenPattern = "\"(.*?)\"";
                    token = (Regex.Match(tokenSubString, tokenPattern)).Value.Replace("\"", "");
                }
            }
            return token;

        }

        IElement GetElementBySelector(IHtmlDocument document, string selector)
        {
            var sdf = document.QuerySelector(selector);
            return document.QuerySelector(selector);
        }

        string GetInnerContentBySelector(IHtmlDocument document, string selector)
        {
            return document.QuerySelector(selector).InnerHtml;
        }

        string GetAtributeBySelector(IHtmlDocument document, string selector, string attribute)
        {
            return document.QuerySelector(selector).GetAttribute(attribute);
        }

        IHtmlCollection<IElement> GetElementsBySelector(IHtmlDocument document, string selector)
        {
            return document.QuerySelectorAll(selector);
        }

        #endregion Method
    }
}
