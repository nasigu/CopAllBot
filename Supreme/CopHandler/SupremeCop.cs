using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Supreme.Core.KeywordSearchEngine;
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

        private async Task<string> GetContent()
        {
            return await DownloadHtmlAsync(SiteName + SiteProductList);
        } 

        public  override async void FindItem()
        {
            var MobileStockJsonString = await DownloadHtmlAsync(SiteName + SiteProductList);

            MobileStock data = MobileStock.FromJson(MobileStockJsonString);
            string IdOfProduct = GetIdByTask(data, CurrentTask);

            throw new NotImplementedException();
        }

        private string GetIdByTask(MobileStock data, Model.Task task)
        {



            var keywords = task.Product.Split(',').ToList();

            var ahoCorasick = AhoCorasick.CreateBuilder().SetWords(keywords).Build();
            
            string IdOfProduct = SearchProcess(task.Category) == "" ? SearchProcess("new") : 
            {

            }

            if (data.ProductsAndCategories.ContainsKey(task.Category))
            {
                foreach (var item in data.ProductsAndCategories[task.Category])
                {
                    if (ahoCorasick.Search(ahoCorasick, item.Name))
                    {
                        return item.Id.ToString();
                    }
                }
            }
            else
            {
                if (data.ProductsAndCategories.ContainsKey("new"))
                {
                    foreach (var item in data.ProductsAndCategories["new"])
                    {
                        if (ahoCorasick.Search(ahoCorasick, item.Name))
                        {
                            return item.Id.ToString();
                        }
                    }
                }
            }

            string SearchProcess(string category)
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

            return "";
        }



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


    }
}
