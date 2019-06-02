using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Supreme.Core.KeywordSearchEngine;
using Supreme.Model;
using Supreme.Model.Supreme;

namespace Supreme.CopHandler
{
    public class SupremeCop : BaseCop
    {
        public Model.Task CurrentTask { get; set; }

        //protected string SiteName = "https://www.supremenewyork.com";
        //protected string SiteProductList = "mobile_stock.json";

        public SupremeCop(Model.Task task)
        {
            CurrentTask = task;
        }

        protected override string SiteName { get; set; } = "https://www.supremenewyork.com/";
        protected override string SiteProductList { get; set; } = "mobile_stock.json";


        #region Method

        #region FindItem

        public override async void FindItem()
        {
            var MobileStockJsonString = await DownloadHtmlAsync(SiteName + SiteProductList);

            var data = MobileStock.FromJson(MobileStockJsonString);

            var IdOfProduct = GetIdByTask(data, CurrentTask);

            Product productData;

            if (IdOfProduct != "")
            {
                string ProductJson = await DownloadHtmlAsync($"https://www.supremenewyork.com/shop/{IdOfProduct}.json");
                productData = Product.FromJson(ProductJson);
            }
            else
            {
                // TODO: Log system
                throw new NotImplementedException();
            }

            var ColorId = "";
            var SizeId = "";
            GetColorAndSizeIdByTask(productData, CurrentTask, out ColorId, out SizeId);

        }

        private void GetColorAndSizeIdByTask(Product data, Model.Task task, out string ColorId, out string SizeId)
        {
            var colorKeywords = task.Style.Split(',').ToList();
            var sizeKeywords = new List<string>() { "+" + task.Size };

            var ahoCorasickColor = AhoCorasick.CreateBuilder().SetWords(colorKeywords).Build();
            var ahoCorasickSize = AhoCorasick.CreateBuilder().SetWords(sizeKeywords).Build();
            ColorId = "";
            SizeId = "";
            foreach (var item in data.Styles)
            {
                if (!ahoCorasickColor.Search(ahoCorasickColor, item.Name)) continue;
                ColorId = item.Id.ToString();

                foreach (var size in item.Sizes)
                {
                    if (ahoCorasickSize.Search(ahoCorasickSize, size.Name.ToString()))
                    {
                        SizeId = size.Id.ToString();
                        break;
                    }
                }
                break;
            }
        }

        private string GetIdByTask(MobileStock data, Model.Task task)
        {
            var keywords = task.Product.Split(',').ToList();

            var ahoCorasick = AhoCorasick.CreateBuilder().SetWords(keywords).Build();

            var idOfProduct = SearchIdProcess(task.Category);

            return idOfProduct == "" ? SearchIdProcess("new") : idOfProduct;

            string SearchIdProcess(string category)
            {
                if (data.ProductsAndCategories.ContainsKey(category))
                {
                    foreach (var item in data.ProductsAndCategories[category])
                    {
                        if (ahoCorasick.Search(ahoCorasick, item.Name))
                        {
                            return item.Id.ToString();
                        }
                    }
                }
                return "";
            }
        }

        private string GetIdByTaskParallel(MobileStock data, Model.Task task)
        {
            var keywords = task.Product.Split(',').ToList();

            var ahoCorasick = AhoCorasick.CreateBuilder().SetWords(keywords).Build();

            var idOfProduct = SearchIdProcess(task.Category);

            return idOfProduct == "" ? SearchIdProcess("new") : idOfProduct;

            if (data.ProductsAndCategories.ContainsKey(task.Category))
            {
                ParallelLoopResult result = Parallel.ForEach(data.ProductsAndCategories[task.Category], sdf);

            }

            void sdf(ProductsAndCategory ca, ParallelLoopState state)
            {
                if (ahoCorasick.Search(ahoCorasick, ca.Name))
                {
                    state.Break();
                }
            }


            string SearchIdProcess(string category)
            {

                if (data.ProductsAndCategories.ContainsKey(category))
                {

                    foreach (var item in data.ProductsAndCategories[category])
                    {
                        if (ahoCorasick.Search(ahoCorasick, item.Name))
                        {
                            return item.Id.ToString();
                        }
                    }
                }
                return "";
            }
        }

        #endregion

        public class SupremeCheckoutRequest
        {
            #region Property

            public string StoreCreditId { get; set; } = "";

            public string FromMobile { get; set; } = "1";

            public string CookieSub { get; set; } = "";

            public string SameAsBillingAddress { get; set; } = "1";

            public string BillingName { get; set; } = "";

            public string Email { get; set; } = "";

            public string Tel { get; set; } = "";

            public string BillingAddress { get; set; } = "";

            public string BillingAddress2 { get; set; } = "";

            public string BillingAddress3 { get; set; } = "";

            public string BillingCity { get; set; } = "";

            public string BillingZip { get; set; } = "";

            public string BillingCountry { get; set; } = "";

            public string CardType { get; set; } = "";

            public string CardNumber { get; set; } = "";

            public string Month { get; set; } = "";

            public string Year { get; set; } = "";

            public string Vval { get; set; } = "";

            public string OrderTerms0 { get; set; } = "0";

            public string OrderTerms1 { get; set; } = "1";

            public string GRecaptchaResponse { get; set; } = "";

            #endregion

            #region Constructor

            public SupremeCheckoutRequest(Profile profile)
            {
                BillingName = profile.ProfileFullName;
                Email = profile.ProfileEmail;
                Tel = profile.ProfileTel;
                BillingAddress = profile.ProfileAddress;
                BillingAddress2 = profile.ProfileAddress2;
                BillingAddress3 = profile.ProfileAddress3;
                BillingCity = profile.ProfileCity;
                BillingZip = profile.ProfilePostCode;
                BillingCountry = profile.ProfileCountry;
                CardType = profile.ProfileCreditCardType;
                CardNumber = profile.ProfileCreditCardNumber;
                Month = profile.ProfileExpiryMonth < 10
                    ? "0" + profile.ProfileExpiryMonth
                    : profile.ProfileExpiryMonth.ToString();
                Year = profile.ProfileExpiryYear.ToString();
                Vval = profile.ProfileCardCVV.ToString();

                WebRequest request = (HttpWebRequest) WebRequest.Create("https://www.supremenewyork.com/checkout.json");
                request.Method = "POST";

                ////abDuMMD41d3eITY0e3Sq6RN7hoy2gP/SSA6xTtGhM1LPuiYl5bHUe36heSpIUlDLH1H0ANW8dR1zmxTSLtHy6g==
                /// 74OaR0fSk8ucKqdJ5vWA2eaO4SDFLVOWt7x+MYCBCKO+80s5Tv6k3ybOUd1TdvVzLct8uPL4aqTB+U4U5ONaPA==
                /// k8wIofezcKeL/YCFGCzkr1gjiJCPT1gQ/6k9vg/5lefl8R/kEWKi8+hKudtUvfL3gCX31o2oORW5jWeRlU9opg==
                /// 
            }

        }

        #endregion

            #region Method

            #endregion

        //    private async Task<string> PostRequestAsync()
        //{
            //string Source = await DownloadHtmlAsync("https://www.supremenewyork.com/mobile/#checkout");

            //var CSRFToken = GetCSRFToken(Document);

            //string billing_name = "Super Svin";
            //string email = "nkatrvld@gmail.com";
            //string tel = "+79347834736";
            //string billing_address = "Pushkina 8";
            //string billing_address_2 = "";
            //string billing_address_3 = "";
            //string billing_city = "Moscow";
            //string billing_zip = "119603";
            //string billing_country = "RU";
            //string same_as_billing_address = "1";
            //string type = "master";
            //string cnb = "5321 3045 7241 2143";
            //string month = "11";
            //string year = "2023";
            //string vval = "159";
            //string termsFirtst = "0";
            //string termsSecond = "1";
            //string g_recaptcha_response = "03AOLTBLRdNpSCMIPMyrDATG8hPSDX0Boq9w4z06XXwUOhAxp_5_IUuz9ceo-aRiARVQqNxj0s0T023-nhEGd3oGh3Mc9vc-W0-2YUKmTQqNHZyuce5oW9iV595u3gFmzUyG880yXA9x8r6CLsXzbbsPhA-VvmHl2JONcZoRqoozCcuiaUMCt40x_r4Ngf-8dH2Cg56zPhxia_fDZNaMmmsrZGWF8i0lMJx6slhIQpoYgR0Oy8rGZzEeTM9Npb3EdpUDpdPV9Rpxy3-8vShV1uLAcrhQoIJGEBezHHH3pL0ECX4ab8cJNmGTDG6oY1NepzFKpMoyZIUWDj";
            //string hpcvv = "";

            ///////////////////////

            //var store_credit_id = "";

            

            //WebRequest request = (HttpWebRequest)WebRequest.Create("https://www.supremenewyork.com/checkout.json");
            //request.Method = "POST"; // для отправки используется метод Post
            //                         // данные для отправки
            //string data = $"store_credit_id = {store_credit_id}, from_mobile = 1, cookie-sub = {{\"55920\":1}}, same_as_billing_address = {same_as_billing_address}, authenticity_token = {CSRFToken}, "
            //    + $"order[billing_name] = {billing_name}, order[email] = {email}, order[tel] = {tel}, order[billing_address] = {billing_address}, order[billing_address_2] = {billing_address_2}, "
            //    + $"order[billing_address_3] = {billing_address_3}, order[billing_city] = {billing_city}, order[billing_zip] = {billing_zip}, order[billing_country] = {billing_country}, "
            //    + $"credit_card[type] = {type}, credit_card[cnb] = {cnb}, credit_card[month] = {month}, credit_card[year] = {year}, credit_card[vval] = {vval}, "
            //    + $"order[terms] = 0, order[terms] = 1, g-recaptcha-response = {g_recaptcha_response}";
            //// преобразуем данные в массив байтов
            //byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            //// устанавливаем тип содержимого - параметр ContentType
            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            //// Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            //request.ContentLength = byteArray.Length;
            //request.Headers.Add("x-csrf-token", CSRFToken);
            //var ssss = cookie(Documentcookie);
            //request.Headers.Add("Cookie", ssss);
            ////request.Headers.Add("Accept", "*/*");

            ////request.Headers.Add("Accept", "*/*");


            ////записываем данные в поток запроса
            //using (Stream dataStream = request.GetRequestStream())
            //{
            //    dataStream.Write(byteArray, 0, byteArray.Length);
            //}

            //WebResponse response = await request.GetResponseAsync();
            //string resp = "";
            //using (Stream stream = response.GetResponseStream())
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        resp = reader.ReadToEnd();
            //        Console.WriteLine("Response: " + resp);
            //    }
            //}
            //response.Close();
            //Console.WriteLine("Запрос выполнен...");
            //return resp;

        //}

        public override void Checkout()
        {
            throw new NotImplementedException();
        }

        public override void Payment()
        {
            throw new NotImplementedException();
        }

        public override void GetCopStatus()
        {
            throw new NotImplementedException();
        }

        #endregion




    }
}
